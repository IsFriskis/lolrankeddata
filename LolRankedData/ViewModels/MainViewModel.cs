using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LolRankedData.Models;
using LolRankedData.Services;

namespace LolRankedData.ViewModels;

/// <summary>
/// Main view model for the ranked games display.
/// </summary>
public partial class MainViewModel : ObservableObject
{
    private readonly IRiotApiService _riotApiService;

    [ObservableProperty]
    private string _gameName = string.Empty;

    [ObservableProperty]
    private string _tagLine = string.Empty;

    [ObservableProperty]
    private string _apiKey = string.Empty;

    [ObservableProperty]
    private string _selectedRegion = "euw1";

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [ObservableProperty]
    private int _matchCount = 20;

    [ObservableProperty]
    private RiotAccount? _currentAccount;

    [ObservableProperty]
    private Summoner? _currentSummoner;

    [ObservableProperty]
    private LeagueEntry? _soloQueueEntry;

    [ObservableProperty]
    private LeagueEntry? _flexQueueEntry;

    public ObservableCollection<RankedGameDisplay> RankedGames { get; } = new();

    public List<string> AvailableRegions { get; } = new()
    {
        "na1", "euw1", "eun1", "kr", "br1", "la1", "la2", "oc1", "ru", "tr1", "jp1"
    };

    public List<int> MatchCountOptions { get; } = new() { 10, 20, 30, 50, 100 };

    public MainViewModel(IRiotApiService riotApiService)
    {
        _riotApiService = riotApiService;
    }

    [RelayCommand]
    private async Task FetchRankedDataAsync()
    {
        if (string.IsNullOrWhiteSpace(ApiKey))
        {
            ErrorMessage = "Please enter your Riot API key.";
            return;
        }

        if (string.IsNullOrWhiteSpace(GameName) || string.IsNullOrWhiteSpace(TagLine))
        {
            ErrorMessage = "Please enter a valid Riot ID (Game Name#Tag).";
            return;
        }

        ErrorMessage = string.Empty;
        IsLoading = true;
        StatusMessage = "Fetching account information...";

        try
        {
            _riotApiService.ApiKey = ApiKey;
            _riotApiService.Region = SelectedRegion;

            // Get account info
            CurrentAccount = await _riotApiService.GetAccountByRiotIdAsync(GameName, TagLine);
            if (CurrentAccount == null)
            {
                ErrorMessage = "Could not find account. Please check the Riot ID and try again.";
                return;
            }

            StatusMessage = $"Found account: {CurrentAccount.RiotId}";

            // Get summoner info
            CurrentSummoner = await _riotApiService.GetSummonerByPuuidAsync(CurrentAccount.Puuid);

            // Get league entries
            if (CurrentSummoner != null)
            {
                var leagueEntries = await _riotApiService.GetLeagueEntriesAsync(CurrentSummoner.Id);
                SoloQueueEntry = leagueEntries.FirstOrDefault(e => e.QueueType == "RANKED_SOLO_5x5");
                FlexQueueEntry = leagueEntries.FirstOrDefault(e => e.QueueType == "RANKED_FLEX_SR");
            }

            StatusMessage = "Fetching ranked games...";

            // Clear existing games
            RankedGames.Clear();

            // Get ranked games
            var games = await _riotApiService.GetRankedGamesAsync(GameName, TagLine, MatchCount);

            foreach (var game in games)
            {
                RankedGames.Add(game);
            }

            StatusMessage = $"Found {RankedGames.Count} ranked games.";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private void ClearData()
    {
        RankedGames.Clear();
        CurrentAccount = null;
        CurrentSummoner = null;
        SoloQueueEntry = null;
        FlexQueueEntry = null;
        StatusMessage = string.Empty;
        ErrorMessage = string.Empty;
    }
}
