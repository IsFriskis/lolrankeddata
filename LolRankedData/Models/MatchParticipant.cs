using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents match participant data from Riot API.
/// </summary>
public class MatchParticipant
{
    [JsonPropertyName("assists")]
    public int Assists { get; set; }

    [JsonPropertyName("baronKills")]
    public int BaronKills { get; set; }

    [JsonPropertyName("bountyLevel")]
    public int BountyLevel { get; set; }

    [JsonPropertyName("champExperience")]
    public int ChampExperience { get; set; }

    [JsonPropertyName("champLevel")]
    public int ChampLevel { get; set; }

    [JsonPropertyName("championId")]
    public int ChampionId { get; set; }

    [JsonPropertyName("championName")]
    public string ChampionName { get; set; } = string.Empty;

    [JsonPropertyName("damageDealtToBuildings")]
    public int DamageDealtToBuildings { get; set; }

    [JsonPropertyName("damageDealtToObjectives")]
    public int DamageDealtToObjectives { get; set; }

    [JsonPropertyName("damageDealtToTurrets")]
    public int DamageDealtToTurrets { get; set; }

    [JsonPropertyName("deaths")]
    public int Deaths { get; set; }

    [JsonPropertyName("doubleKills")]
    public int DoubleKills { get; set; }

    [JsonPropertyName("dragonKills")]
    public int DragonKills { get; set; }

    [JsonPropertyName("firstBloodAssist")]
    public bool FirstBloodAssist { get; set; }

    [JsonPropertyName("firstBloodKill")]
    public bool FirstBloodKill { get; set; }

    [JsonPropertyName("firstTowerAssist")]
    public bool FirstTowerAssist { get; set; }

    [JsonPropertyName("firstTowerKill")]
    public bool FirstTowerKill { get; set; }

    [JsonPropertyName("goldEarned")]
    public int GoldEarned { get; set; }

    [JsonPropertyName("goldSpent")]
    public int GoldSpent { get; set; }

    [JsonPropertyName("individualPosition")]
    public string IndividualPosition { get; set; } = string.Empty;

    [JsonPropertyName("item0")]
    public int Item0 { get; set; }

    [JsonPropertyName("item1")]
    public int Item1 { get; set; }

    [JsonPropertyName("item2")]
    public int Item2 { get; set; }

    [JsonPropertyName("item3")]
    public int Item3 { get; set; }

    [JsonPropertyName("item4")]
    public int Item4 { get; set; }

    [JsonPropertyName("item5")]
    public int Item5 { get; set; }

    [JsonPropertyName("item6")]
    public int Item6 { get; set; }

    [JsonPropertyName("kills")]
    public int Kills { get; set; }

    [JsonPropertyName("lane")]
    public string Lane { get; set; } = string.Empty;

    [JsonPropertyName("largestKillingSpree")]
    public int LargestKillingSpree { get; set; }

    [JsonPropertyName("largestMultiKill")]
    public int LargestMultiKill { get; set; }

    [JsonPropertyName("magicDamageDealt")]
    public int MagicDamageDealt { get; set; }

    [JsonPropertyName("magicDamageDealtToChampions")]
    public int MagicDamageDealtToChampions { get; set; }

    [JsonPropertyName("magicDamageTaken")]
    public int MagicDamageTaken { get; set; }

    [JsonPropertyName("neutralMinionsKilled")]
    public int NeutralMinionsKilled { get; set; }

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; set; }

    [JsonPropertyName("pentaKills")]
    public int PentaKills { get; set; }

    [JsonPropertyName("physicalDamageDealt")]
    public int PhysicalDamageDealt { get; set; }

    [JsonPropertyName("physicalDamageDealtToChampions")]
    public int PhysicalDamageDealtToChampions { get; set; }

    [JsonPropertyName("physicalDamageTaken")]
    public int PhysicalDamageTaken { get; set; }

    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("quadraKills")]
    public int QuadraKills { get; set; }

    [JsonPropertyName("riotIdGameName")]
    public string RiotIdGameName { get; set; } = string.Empty;

    [JsonPropertyName("riotIdTagline")]
    public string RiotIdTagline { get; set; } = string.Empty;

    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;

    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; set; }

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; set; } = string.Empty;

    [JsonPropertyName("teamId")]
    public int TeamId { get; set; }

    [JsonPropertyName("teamPosition")]
    public string TeamPosition { get; set; } = string.Empty;

    [JsonPropertyName("timePlayed")]
    public int TimePlayed { get; set; }

    [JsonPropertyName("totalDamageDealt")]
    public int TotalDamageDealt { get; set; }

    [JsonPropertyName("totalDamageDealtToChampions")]
    public int TotalDamageDealtToChampions { get; set; }

    [JsonPropertyName("totalDamageShieldedOnTeammates")]
    public int TotalDamageShieldedOnTeammates { get; set; }

    [JsonPropertyName("totalDamageTaken")]
    public int TotalDamageTaken { get; set; }

    [JsonPropertyName("totalHeal")]
    public int TotalHeal { get; set; }

    [JsonPropertyName("totalHealsOnTeammates")]
    public int TotalHealsOnTeammates { get; set; }

    [JsonPropertyName("totalMinionsKilled")]
    public int TotalMinionsKilled { get; set; }

    [JsonPropertyName("tripleKills")]
    public int TripleKills { get; set; }

    [JsonPropertyName("trueDamageDealt")]
    public int TrueDamageDealt { get; set; }

    [JsonPropertyName("trueDamageDealtToChampions")]
    public int TrueDamageDealtToChampions { get; set; }

    [JsonPropertyName("trueDamageTaken")]
    public int TrueDamageTaken { get; set; }

    [JsonPropertyName("turretKills")]
    public int TurretKills { get; set; }

    [JsonPropertyName("visionScore")]
    public int VisionScore { get; set; }

    [JsonPropertyName("visionWardsBoughtInGame")]
    public int VisionWardsBoughtInGame { get; set; }

    [JsonPropertyName("wardsKilled")]
    public int WardsKilled { get; set; }

    [JsonPropertyName("wardsPlaced")]
    public int WardsPlaced { get; set; }

    [JsonPropertyName("win")]
    public bool Win { get; set; }

    /// <summary>
    /// Gets the KDA string (e.g., "5/2/10").
    /// </summary>
    public string Kda => $"{Kills}/{Deaths}/{Assists}";

    /// <summary>
    /// Gets the KDA ratio.
    /// </summary>
    public double KdaRatio => Deaths > 0 ? (double)(Kills + Assists) / Deaths : Kills + Assists;

    /// <summary>
    /// Gets the CS (Creep Score).
    /// </summary>
    public int Cs => TotalMinionsKilled + NeutralMinionsKilled;

    /// <summary>
    /// Gets the full Riot ID (GameName#Tagline).
    /// </summary>
    public string RiotId => string.IsNullOrEmpty(RiotIdTagline) ? RiotIdGameName : $"{RiotIdGameName}#{RiotIdTagline}";
}
