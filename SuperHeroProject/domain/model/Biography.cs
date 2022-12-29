namespace SuperHeroBackend.domain.model
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