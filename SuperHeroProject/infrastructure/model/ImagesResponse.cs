using System.Text.Json.Serialization;

namespace SuperHeroBackend.infrastructure.model
{
    public record ImagesResponse
    {
        [JsonPropertyName("xs")] public string Xs { get; init; }
        [JsonPropertyName("sm")] public string Sm { get; init; }
        [JsonPropertyName("md")] public string Md { get; init; }
        [JsonPropertyName("lg")] public string Lg { get; init; }
    }
}