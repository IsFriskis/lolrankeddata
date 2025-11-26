using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents match metadata from Riot API.
/// </summary>
public class MatchMetadata
{
    [JsonPropertyName("dataVersion")]
    public string DataVersion { get; set; } = string.Empty;

    [JsonPropertyName("matchId")]
    public string MatchId { get; set; } = string.Empty;

    [JsonPropertyName("participants")]
    public List<string> Participants { get; set; } = new();
}
