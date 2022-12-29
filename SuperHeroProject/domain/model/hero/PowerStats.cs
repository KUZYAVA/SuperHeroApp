namespace SuperHeroBackend.domain.model.hero
{
    public record PowerStats(
        int Intelligence,
        int Strength,
        int Speed,
        int Durability,
        int Power,
        int Combat
    );
}