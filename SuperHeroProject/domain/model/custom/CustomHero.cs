namespace SuperHeroBackend.domain.model.custom
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record CustomHero
    (
        string Id,
        string Name,
        string Biography,
        string Image,
        PowerStats PowerStats
    );
}