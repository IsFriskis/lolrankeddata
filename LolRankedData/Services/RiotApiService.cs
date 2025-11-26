using System.Net.Http.Json;
using System.Text.Json;
using LolRankedData.Models;

namespace LolRankedData.Services;

/// <summary>
/// Implementation of Riot Games API service for fetching League of Legends data.
/// </summary>
public class RiotApiService : IRiotApiService, IDisposable
{
    private readonly HttpClient _httpClient;
    private string _apiKey = string.Empty;
    private string _region = "euw1";
    private bool _disposed;

    /// <summary>
    /// Delay between API requests in milliseconds to respect Riot API rate limits.
    /// Default is 50ms which allows ~20 requests per second (well under the 100 req/2min limit).
    /// </summary>
    private const int RateLimitDelayMs = 50;

    // Region to routing value mapping for regional endpoints
    private static readonly Dictionary<string, string> RegionRouting = new()
    {
        { "na1", "americas" },
        { "br1", "americas" },
        { "la1", "americas" },
        { "la2", "americas" },
        { "euw1", "europe" },
        { "eun1", "europe" },
        { "tr1", "europe" },
        { "ru", "europe" },
        { "kr", "asia" },
        { "jp1", "asia" },
        { "oc1", "sea" },
        { "ph2", "sea" },
        { "sg2", "sea" },
        { "th2", "sea" },
        { "tw2", "sea" },
        { "vn2", "sea" }
    };

    public RiotApiService()
    {
        _httpClient = new HttpClient();
    }

    public string ApiKey
    {
        get => _apiKey;
        set => _apiKey = value;
    }

    public string Region
    {
        get => _region;
        set => _region = value.ToLowerInvariant();
    }

    private string GetRoutingValue()
    {
        return RegionRouting.TryGetValue(_region, out var routing) ? routing : "europe";
    }

    private string GetPlatformUrl()
    {
        return $"https://{_region}.api.riotgames.com";
    }

    private string GetRegionalUrl()
    {
        return $"https://{GetRoutingValue()}.api.riotgames.com";
    }

    private void AddApiKey(HttpRequestMessage request)
    {
        request.Headers.Add("X-Riot-Token", _apiKey);
    }

    public async Task<RiotAccount?> GetAccountByRiotIdAsync(string gameName, string tagLine)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new InvalidOperationException("API key is not set.");
        }

        var url = $"{GetRegionalUrl()}/riot/account/v1/accounts/by-riot-id/{Uri.EscapeDataString(gameName)}/{Uri.EscapeDataString(tagLine)}";

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        AddApiKey(request);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<RiotAccount>();
    }

    public async Task<Summoner?> GetSummonerByPuuidAsync(string puuid)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new InvalidOperationException("API key is not set.");
        }

        var url = $"{GetPlatformUrl()}/lol/summoner/v4/summoners/by-puuid/{puuid}";

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        AddApiKey(request);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<Summoner>();
    }

    public async Task<List<LeagueEntry>> GetLeagueEntriesAsync(string summonerId)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new InvalidOperationException("API key is not set.");
        }

        var url = $"{GetPlatformUrl()}/lol/league/v4/entries/by-summoner/{summonerId}";

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        AddApiKey(request);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return new List<LeagueEntry>();
        }

        return await response.Content.ReadFromJsonAsync<List<LeagueEntry>>() ?? new List<LeagueEntry>();
    }

    public async Task<List<string>> GetRankedMatchIdsAsync(string puuid, int count = 20)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new InvalidOperationException("API key is not set.");
        }

        // Queue type 420 = Ranked Solo/Duo, 440 = Ranked Flex
        var url = $"{GetRegionalUrl()}/lol/match/v5/matches/by-puuid/{puuid}/ids?type=ranked&count={count}";

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        AddApiKey(request);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return new List<string>();
        }

        return await response.Content.ReadFromJsonAsync<List<string>>() ?? new List<string>();
    }

    public async Task<Match?> GetMatchAsync(string matchId)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new InvalidOperationException("API key is not set.");
        }

        var url = $"{GetRegionalUrl()}/lol/match/v5/matches/{matchId}";

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        AddApiKey(request);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<Match>();
    }

    public async Task<List<RankedGameDisplay>> GetRankedGamesAsync(string gameName, string tagLine, int count = 20)
    {
        var games = new List<RankedGameDisplay>();

        // Get account info
        var account = await GetAccountByRiotIdAsync(gameName, tagLine);
        if (account == null)
        {
            return games;
        }

        // Get ranked match IDs
        var matchIds = await GetRankedMatchIdsAsync(account.Puuid, count);

        // Fetch each match
        foreach (var matchId in matchIds)
        {
            var match = await GetMatchAsync(matchId);
            if (match?.Info.IsRanked == true)
            {
                var gameDisplay = RankedGameDisplay.FromMatch(match, account.Puuid);
                games.Add(gameDisplay);
            }

            // Rate limiting - Riot API has rate limits
            await Task.Delay(RateLimitDelayMs);
        }

        return games;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
            _disposed = true;
        }
    }
}
