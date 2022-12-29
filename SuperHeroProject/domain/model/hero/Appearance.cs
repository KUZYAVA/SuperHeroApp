namespace SuperHeroBackend.domain.model.hero
{
    public record Appearance(
        string Gender,
        string Race,
        string EyeColor,
        string HairColor,
        string[] Height,
        string[] Weight
    );
}