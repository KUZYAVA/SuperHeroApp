using System.Text.Json.Serialization;

namespace SuperHeroBackend.infrastructure.model
{
    public record ConnectionsResponse
    {
        [JsonPropertyName("groupAffiliation")] public string GroupAffiliation { get; init; }
        [JsonPropertyName("relatives")] public string Relatives { get; init; }
    }
}