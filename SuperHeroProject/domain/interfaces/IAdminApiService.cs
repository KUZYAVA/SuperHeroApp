using SuperHeroBackend.domain.model.enums;
using SuperHeroBackend.domain.model.market;

namespace SuperHeroProject.domain.interfaces
{
    public interface IAdminApiService
    {
        public void ChangeMarketStateOfHero( MarketState marketState, MarketHero hero);
        public MarketHero GetHeroByIdFromWaiting(string heroId);
        public void DeleteHeroByIdFromWaiting(string heroId);
    }
}