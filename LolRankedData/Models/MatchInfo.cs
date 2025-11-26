using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents match information from Riot API.
/// </summary>
public class MatchInfo
{
    [JsonPropertyName("gameCreation")]
    public long GameCreation { get; set; }

    [JsonPropertyName("gameDuration")]
    public long GameDuration { get; set; }

    [JsonPropertyName("gameEndTimestamp")]
    public long GameEndTimestamp { get; set; }

    [JsonPropertyName("gameId")]
    public long GameId { get; set; }

    [JsonPropertyName("gameMode")]
    public string GameMode { get; set; } = string.Empty;

    [JsonPropertyName("gameName")]
    public string GameName { get; set; } = string.Empty;

    [JsonPropertyName("gameType")]
    public string GameType { get; set; } = string.Empty;

    [JsonPropertyName("gameVersion")]
    public string GameVersion { get; set; } = string.Empty;

    [JsonPropertyName("mapId")]
    public int MapId { get; set; }

    [JsonPropertyName("platformId")]
    public string PlatformId { get; set; } = string.Empty;

    [JsonPropertyName("queueId")]
    public int QueueId { get; set; }

    [JsonPropertyName("participants")]
    public List<MatchParticipant> Participants { get; set; } = new();

    [JsonPropertyName("teams")]
    public List<MatchTeam> Teams { get; set; } = new();

    /// <summary>
    /// Gets the game creation date as DateTime.
    /// </summary>
    public DateTime GameCreationDate => DateTimeOffset.FromUnixTimeMilliseconds(GameCreation).LocalDateTime;

    /// <summary>
    /// Gets the formatted game duration.
    /// </summary>
    public string FormattedDuration => TimeSpan.FromSeconds(GameDuration).ToString(@"mm\:ss");

    /// <summary>
    /// Checks if this is a ranked game.
    /// </summary>
    public bool IsRanked => QueueId == 420 || QueueId == 440; // 420 = Solo/Duo, 440 = Flex
}
