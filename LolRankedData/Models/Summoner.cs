using System.Text.Json.Serialization;

namespace LolRankedData.Models;

/// <summary>
/// Represents summoner account information from Riot API.
/// </summary>
public class Summoner
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("accountId")]
    public string AccountId { get; set; } = string.Empty;

    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("profileIconId")]
    public int ProfileIconId { get; set; }

    [JsonPropertyName("revisionDate")]
    public long RevisionDate { get; set; }

    [JsonPropertyName("summonerLevel")]
    public long SummonerLevel { get; set; }
}
