namespace SuperHeroBackend.domain.model.hero
{
    public record Biography(
        string FullName,
        string AlterEgos,
        string[] Aliases,
        string PlaceOfBirth,
        string FirstAppearance,
        string Publisher,
        string Alignment
    );
}