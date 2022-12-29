using System.Collections.Generic;
using SuperHeroBackend.domain.model;
using SuperHeroBackend.domain.model.enums;
using SuperHeroBackend.domain.model.market;

namespace SuperHeroProject.domain.interfaces
{
    public interface IMarketApiService
    {
        public void AddHeroToMarket(MarketHero hero);
        public IEnumerable<MarketHero> GetAllHeroesByUserId(string userId);
        public IEnumerable<MarketHero> GetAllHeroesAtMarket();
        public BuyHeroState BuyHeroAtMarket(User user, string heroId);
    }
}