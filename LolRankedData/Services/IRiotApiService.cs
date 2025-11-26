using LolRankedData.Models;

namespace LolRankedData.Services;

/// <summary>
/// Interface for Riot Games API service.
/// </summary>
public interface IRiotApiService
{
    /// <summary>
    /// Gets or sets the Riot API key.
    /// </summary>
    string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the region for API calls.
    /// </summary>
    string Region { get; set; }

    /// <summary>
    /// Gets a Riot account by game name and tag line.
    /// </summary>
    Task<RiotAccount?> GetAccountByRiotIdAsync(string gameName, string tagLine);

    /// <summary>
    /// Gets summoner information by PUUID.
    /// </summary>
    Task<Summoner?> GetSummonerByPuuidAsync(string puuid);

    /// <summary>
    /// Gets league entries (ranked data) for a summoner.
    /// </summary>
    Task<List<LeagueEntry>> GetLeagueEntriesAsync(string summonerId);

    /// <summary>
    /// Gets ranked match IDs for a player.
    /// </summary>
    Task<List<string>> GetRankedMatchIdsAsync(string puuid, int count = 20);

    /// <summary>
    /// Gets match details by match ID.
    /// </summary>
    Task<Match?> GetMatchAsync(string matchId);

    /// <summary>
    /// Gets all ranked games for a player.
    /// </summary>
    Task<List<RankedGameDisplay>> GetRankedGamesAsync(string gameName, string tagLine, int count = 20);
}
