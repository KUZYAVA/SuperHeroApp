using System.Text.Json.Serialization;

namespace SuperHeroBackend.infrastructure.model
{
    public record BiographyResponse
    {
        [JsonPropertyName("fullName")] public string FullName { get; init; }
        [JsonPropertyName("alterEgos")] public string AlterEgos { get; init; }
        [JsonPropertyName("aliases")] public string[] Aliases { get; init; }
        [JsonPropertyName("placeOfBirth")] public string PlaceOfBirth { get; init; }
        [JsonPropertyName("firstAppearance")] public string FirstAppearance { get; init; }
        [JsonPropertyName("publisher")] public string Publisher { get; init; }
        [JsonPropertyName("alignment")] public string Alignment { get; init; }
    }
}