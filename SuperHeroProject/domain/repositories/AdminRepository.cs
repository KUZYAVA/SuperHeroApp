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

namespace SuperHeroBackend.domain.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AdminRepository
    {
        private readonly IAdminApiService service;
        private readonly IUserDatabase database;

        public AdminRepository(IAdminApiService service, IUserDatabase database)
        {
            this.service = service;
            this.database = database;
        }

        public Result ChangeMarketStateOfHero(string heroId, MarketState marketState)
        {
            try
            {
                var userId = database.GetUserId();
                var hero = service.GetHeroByIdFromWaiting(heroId);
                service.DeleteHeroByIdFromWaiting(heroId);
                service.ChangeMarketStateOfHero(marketState, hero);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }
    }
}