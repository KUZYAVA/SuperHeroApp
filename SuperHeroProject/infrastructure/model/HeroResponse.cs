using System.Text.Json.Serialization;

namespace SuperHeroBackend.infrastructure.model
{
    public record HeroResponse
    {
        [JsonPropertyName("id")] public int Id { get; init; }
        [JsonPropertyName("name")] public string Name { get; init; }
        [JsonPropertyName("slug")] public string Slug { get; init; }
        [JsonPropertyName("powerstats")] public PowerStatsResponse PowerStats { get; init; }
        [JsonPropertyName("appearance")] public AppearanceResponse Appearance { get; init; }
        [JsonPropertyName("biography")] public BiographyResponse Biography { get; init; }
        [JsonPropertyName("work")] public WorkResponse Work { get; init; }
        [JsonPropertyName("connections")] public ConnectionsResponse Connections { get; init; }
        [JsonPropertyName("images")] public ImagesResponse Images { get; init; }
    }
}