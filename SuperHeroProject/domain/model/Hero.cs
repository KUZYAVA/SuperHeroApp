using SuperHeroBackend.domain.model;

namespace SuperHeroProject.domain.model
{
    public record Hero(
        int Id,
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