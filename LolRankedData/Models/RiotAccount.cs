using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents a Riot account from the Account-V1 API.
/// </summary>
public class RiotAccount
{
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("gameName")]
    public string GameName { get; set; } = string.Empty;

    [JsonPropertyName("tagLine")]
    public string TagLine { get; set; } = string.Empty;

    /// <summary>
    /// Gets the full Riot ID (GameName#TagLine).
    /// </summary>
    public string RiotId => $"{GameName}#{TagLine}";
}
