using SuperHeroBackend.domain.model.custom;
using SuperHeroBackend.domain.model.enums;

namespace SuperHeroBackend.domain.model.market
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record MarketHero
    (
        string Id,
        string UserId,
        CustomHero Hero,
        int Price
    );
}