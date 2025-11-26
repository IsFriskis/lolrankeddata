using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents a complete match from Riot API.
/// </summary>
public class Match
{
    [JsonPropertyName("metadata")]
    public MatchMetadata Metadata { get; set; } = new();

    [JsonPropertyName("info")]
    public MatchInfo Info { get; set; } = new();

    /// <summary>
    /// Gets participant data for the specified PUUID.
    /// </summary>
    public MatchParticipant? GetParticipant(string puuid)
    {
        return Info.Participants.FirstOrDefault(p => p.Puuid == puuid);
    }
}
