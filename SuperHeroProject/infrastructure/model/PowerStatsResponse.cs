using System.Text.Json.Serialization;

namespace SuperHeroBackend.infrastructure.model
{
    public record PowerStatsResponse
    {
        [JsonPropertyName("intelligence")] public int Intelligence { get; init; }
        [JsonPropertyName("strength")] public int Strength { get; init; }
        [JsonPropertyName("speed")] public int Speed { get; init; }
        [JsonPropertyName("durability")] public int Durability { get; init; }
        [JsonPropertyName("power")] public int Power { get; init; }
        [JsonPropertyName("combat")] public int Combat { get; init; }
    }
}