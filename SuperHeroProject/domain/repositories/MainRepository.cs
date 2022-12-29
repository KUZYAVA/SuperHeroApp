using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentResults;
using SuperHeroBackend.domain.model;
using SuperHeroBackend.domain.model.custom;
using SuperHeroBackend.domain.repositories.interfaces;
using SuperHeroBackend.domain.utils;
using SuperHeroProject.domain.interfaces;
using SuperHeroProject.domain.model.hero;
using AuthState = SuperHeroBackend.domain.model.enums.AuthState;
using PowerStats = SuperHeroBackend.domain.model.custom.PowerStats;

namespace SuperHeroProject.domain.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainRepository : IMainRepository
    {
        private readonly IMainApiService service;
        private readonly IUserDatabase database;
        private readonly IHeroApiService heroService;

        public MainRepository(IMainApiService service, IUserDatabase database, IHeroApiService heroService)
        {
            this.service = service;
            this.database = database;
            this.heroService = heroService;
        }

        public Result<List<Hero>> GetAllHeroesFromFavourites()
        {
            try
            {
                var userId = database.GetUserId();
                var listOfHeroIds = service.GetAllHeroesFromFavourites(userId);
                var listOfHeroes = listOfHeroIds.Select(hero => heroService.GetHeroById(hero.Id)).ToList();
                return Result.Ok(listOfHeroes);
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result AddHeroToFavouritesById(string id)
        {
            try
            {
                var userId = database.GetUserId();
                var favHero = new FavouriteHero(id);
                service.AddHeroToFavourites(userId, favHero);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result DeleteHeroFromFavouritesById(string id)
        {
            try
            {
                var userId = database.GetUserId();
                service.DeleteHeroFromFavouritesById(userId, id);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result<List<CustomHero>> GetAllCustomHeroes()
        {
            try
            {
                var userId = database.GetUserId();
                var listOfCustomHeroes = service.GetAllCustomHeroes(userId).ToList();
                return Result.Ok(listOfCustomHeroes);
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result AddCustomHero(
            string name,
            string biography,
            FileStream stream,
            PowerStats powerStats)
        {
            try
            {
                var photoId = Utils.GetNewId();
                var photoUrl = service.UploadPhoto(stream, photoId);

                var heroId = Utils.GetNewId();
                var customHero = new CustomHero(heroId, name, biography, photoUrl, powerStats);
                var userId = database.GetUserId();
                service.AddCustomHero(userId, customHero);

                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result DeleteCustomHeroById(string id)
        {
            try
            {
                var userId = database.GetUserId();
                service.DeleteCustomHeroById(userId, id);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result LoginUser(string userName, string password)
        {
            try
            {
                var authState = service.LoginUser(userName, password);
                return authState switch
                {
                    AuthState.InvalidPassword => Result.Fail("Invalid password"),
                    AuthState.NotRegisterYet => Result.Fail("Not registered yet"),
                    _ => Result.Ok()
                };
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result RegisterUser(string userName, string password)
        {
            try
            {
                var userId = Utils.GetNewId();
                var user = new User(userId, userName, password, 0);
                var authState = service.RegisterUser(user);
                return authState switch
                {
                    AuthState.LoggedAlready => Result.Fail("Logged already"),
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