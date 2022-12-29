using System.Text.Json.Serialization;

namespace SuperHeroBackend.infrastructure.model
{
    public record WorkResponse
    {
        [JsonPropertyName("occupation")] public string Occupation { get; init; }
        [JsonPropertyName("base")] public string Base { get; init; }
    }
}