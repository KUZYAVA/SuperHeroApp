using SuperHeroBackend.domain.model.hero;

namespace SuperHeroProject.domain.model.hero
{
    public record Hero(
        string Id,
        string Name,
        string Slug,
        PowerStats PowerStats,
        Appearance Appearance,
        Biography Biography,
        Work Work,
        Connections Connections,
        Images Images
    );
}