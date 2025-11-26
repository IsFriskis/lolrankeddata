namespace LolRankedData.Models;

/// <summary>
/// Represents a display-friendly ranked game for the UI.
/// </summary>
public class RankedGameDisplay
{
    public string MatchId { get; set; } = string.Empty;
    public string Champion { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Kda { get; set; } = string.Empty;
    public double KdaRatio { get; set; }
    public int Cs { get; set; }
    public int VisionScore { get; set; }
    public int GoldEarned { get; set; }
    public int DamageDealt { get; set; }
    public bool Win { get; set; }
    public string QueueType { get; set; } = string.Empty;
    public DateTime GameDate { get; set; }
    public string Duration { get; set; } = string.Empty;

    /// <summary>
    /// Gets the result display text.
    /// </summary>
    public string Result => Win ? "Victory" : "Defeat";

    /// <summary>
    /// Gets the result color for UI display.
    /// </summary>
    public string ResultColor => Win ? "#28a745" : "#dc3545";

    /// <summary>
    /// Creates a RankedGameDisplay from a Match and participant PUUID.
    /// </summary>
    public static RankedGameDisplay FromMatch(Match match, string puuid)
    {
        var participant = match.GetParticipant(puuid);
        if (participant == null)
        {
            return new RankedGameDisplay { MatchId = match.Metadata.MatchId };
        }

        return new RankedGameDisplay
        {
            MatchId = match.Metadata.MatchId,
            Champion = participant.ChampionName,
            Role = FormatRole(participant.TeamPosition),
            Kda = participant.Kda,
            KdaRatio = Math.Round(participant.KdaRatio, 2),
            Cs = participant.Cs,
            VisionScore = participant.VisionScore,
            GoldEarned = participant.GoldEarned,
            DamageDealt = participant.TotalDamageDealtToChampions,
            Win = participant.Win,
            QueueType = match.Info.QueueId == 420 ? "Solo/Duo" : "Flex",
            GameDate = match.Info.GameCreationDate,
            Duration = match.Info.FormattedDuration
        };
    }

    private static string FormatRole(string teamPosition)
    {
        return teamPosition switch
        {
            "TOP" => "Top",
            "JUNGLE" => "Jungle",
            "MIDDLE" => "Mid",
            "BOTTOM" => "ADC",
            "UTILITY" => "Support",
            _ => teamPosition
        };
    }
}
