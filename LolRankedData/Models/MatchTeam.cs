using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents team data from Riot API match.
/// </summary>
public class MatchTeam
{
    [JsonPropertyName("bans")]
    public List<Ban> Bans { get; set; } = new();

    [JsonPropertyName("objectives")]
    public Objectives Objectives { get; set; } = new();

    [JsonPropertyName("teamId")]
    public int TeamId { get; set; }

    [JsonPropertyName("win")]
    public bool Win { get; set; }

    /// <summary>
    /// Gets the team color name.
    /// </summary>
    public string TeamColor => TeamId == 100 ? "Blue" : "Red";
}

/// <summary>
/// Represents a champion ban.
/// </summary>
public class Ban
{
    [JsonPropertyName("championId")]
    public int ChampionId { get; set; }

    [JsonPropertyName("pickTurn")]
    public int PickTurn { get; set; }
}

/// <summary>
/// Represents team objectives.
/// </summary>
public class Objectives
{
    [JsonPropertyName("baron")]
    public ObjectiveInfo Baron { get; set; } = new();

    [JsonPropertyName("champion")]
    public ObjectiveInfo Champion { get; set; } = new();

    [JsonPropertyName("dragon")]
    public ObjectiveInfo Dragon { get; set; } = new();

    [JsonPropertyName("inhibitor")]
    public ObjectiveInfo Inhibitor { get; set; } = new();

    [JsonPropertyName("riftHerald")]
    public ObjectiveInfo RiftHerald { get; set; } = new();

    [JsonPropertyName("tower")]
    public ObjectiveInfo Tower { get; set; } = new();
}

/// <summary>
/// Represents objective statistics.
/// </summary>
public class ObjectiveInfo
{
    [JsonPropertyName("first")]
    public bool First { get; set; }

    [JsonPropertyName("kills")]
    public int Kills { get; set; }
}
