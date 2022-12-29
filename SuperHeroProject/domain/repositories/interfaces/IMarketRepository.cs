using System.Collections.Generic;
using FluentResults;
using SuperHeroBackend.domain.model.custom;
using SuperHeroBackend.domain.model.market;

namespace SuperHeroBackend.domain.repositories.interfaces
{
    public interface IMarketRepository
    {
        public Result AddHeroToMarket(CustomHero hero, int price);
        public Result<List<MarketHero>> GetAllHeroesByUserId();
        public Result<List<MarketHero>> GetAllHeroesAtMarket();
        public Result BuyHeroAtMarket(string heroId);
    }
}