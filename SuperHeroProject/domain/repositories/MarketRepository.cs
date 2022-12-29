using System;
using System.Collections.Generic;
using System.Linq;
using FluentResults;
using SuperHeroBackend.domain.model.custom;
using SuperHeroBackend.domain.model.enums;
using SuperHeroBackend.domain.model.market;
using SuperHeroBackend.domain.repositories.interfaces;
using SuperHeroBackend.domain.utils;
using SuperHeroProject.domain.interfaces;

namespace SuperHeroProject.domain.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MarketRepository : IMarketRepository
    {
        private readonly IMarketApiService service;
        private readonly IUserDatabase database;

        public MarketRepository(IMarketApiService service, IUserDatabase database)
        {
            this.service = service;
            this.database = database;
        }

        public Result AddHeroToMarket(CustomHero hero, int price)
        {
            try
            {
                var userId = database.GetUserId();
                var marketHeroId = Guid.NewGuid().ToString();
                var marketHero = new MarketHero(marketHeroId, userId, hero, price);
                service.AddHeroToMarket(marketHero);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result<List<MarketHero>> GetAllHeroesByUserId()
        {
            try
            {
                var userId = database.GetUserId();
                var listOfMarketHeroes = service.GetAllHeroesByUserId(userId).ToList();
                return Result.Ok(listOfMarketHeroes);
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result<List<MarketHero>> GetAllHeroesAtMarket()
        {
            try
            {
                var listOfMarketHeroes = service.GetAllHeroesAtMarket().ToList();
                return Result.Ok(listOfMarketHeroes);
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result BuyHeroAtMarket(string heroId)
        {
            try
            {
                var user = database.GetUser();
                var buyHeroState = service.BuyHeroAtMarket(user, heroId);
                return buyHeroState switch
                {
                    BuyHeroState.NotExist => Result.Fail("Not exist"),
                    BuyHeroState.NotEnoughMoney => Result.Fail("Not enough money"),
                    _ => Result.Ok()
                };
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }
    }
}