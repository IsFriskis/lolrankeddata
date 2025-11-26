using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents League entry (ranked data) from Riot API.
/// </summary>
public class LeagueEntry
{
    [JsonPropertyName("leagueId")]
    public string LeagueId { get; set; } = string.Empty;

    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; set; } = string.Empty;

    [JsonPropertyName("queueType")]
    public string QueueType { get; set; } = string.Empty;

    [JsonPropertyName("tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("rank")]
    public string Rank { get; set; } = string.Empty;

    [JsonPropertyName("leaguePoints")]
    public int LeaguePoints { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("losses")]
    public int Losses { get; set; }

    [JsonPropertyName("hotStreak")]
    public bool HotStreak { get; set; }

    [JsonPropertyName("veteran")]
    public bool Veteran { get; set; }

    [JsonPropertyName("freshBlood")]
    public bool FreshBlood { get; set; }

    [JsonPropertyName("inactive")]
    public bool Inactive { get; set; }

    /// <summary>
    /// Gets the display string for the rank (e.g., "Gold IV 75 LP").
    /// </summary>
    public string RankDisplay => $"{Tier} {Rank} {LeaguePoints} LP";

    /// <summary>
    /// Gets the win rate percentage.
    /// </summary>
    public double WinRate => Wins + Losses > 0 ? (double)Wins / (Wins + Losses) * 100 : 0;

    /// <summary>
    /// Gets the display name for the queue type.
    /// </summary>
    public string QueueTypeDisplay => QueueType switch
    {
        "RANKED_SOLO_5x5" => "Ranked Solo/Duo",
        "RANKED_FLEX_SR" => "Ranked Flex",
        _ => QueueType
    };
}
