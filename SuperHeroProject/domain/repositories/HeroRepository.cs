using System;
using System.Collections.Generic;
using System.Linq;
using FluentResults;
using SuperHeroBackend.domain.model.hero;
using SuperHeroBackend.domain.utils;
using SuperHeroProject.domain.interfaces;
using SuperHeroProject.domain.model.hero;
using SuperHeroProject.domain.repositories.interfaces;
using SortType = SuperHeroBackend.domain.SortType;

namespace SuperHeroProject.domain.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HeroRepository : IHeroRepository
    {
        private readonly IHeroApiService service;

        public HeroRepository(IHeroApiService service)
        {
            this.service = service;
        }

        public Result<List<Hero>> GetAllHeroes()
        {
            try
            {
                var allHeroes = service.GetAllHeroes();
                return Result.Ok(allHeroes);
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public Result<Hero> GetHeroById(string id)
        {
            try
            {
                var hero = service.GetHeroById(id);
                return Result.Ok(hero);
            }
            catch (Exception)
            {
                return Result.Fail(Utils.ErrorMessage);
            }
        }

        public List<Hero> SortHeroes(List<Hero> heroes, SortType sortType)
        {
            return sortType switch
            {
                SortType.SortByName => heroes.OrderBy(hero => hero.Name).ToList(),
                SortType.SortByNameDesc => heroes.OrderByDescending(hero => hero.Name).ToList(),
                _ => heroes
            };
        }
    }
}