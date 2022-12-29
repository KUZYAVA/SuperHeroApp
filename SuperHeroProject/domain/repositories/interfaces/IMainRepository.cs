using System.Collections.Generic;
using System.IO;
using FluentResults;
using SuperHeroBackend.domain.model.custom;
using SuperHeroBackend.domain.model.hero;
using SuperHeroProject.domain.model.hero;
using PowerStats = SuperHeroBackend.domain.model.custom.PowerStats;

namespace SuperHeroBackend.domain.repositories.interfaces
{
    public interface IMainRepository
    {
        public Result<List<Hero>> GetAllHeroesFromFavourites();
        public Result AddHeroToFavouritesById(string id);
        public Result DeleteHeroFromFavouritesById(string id);
        public Result<List<CustomHero>> GetAllCustomHeroes();
        public Result AddCustomHero(string name, string biography, FileStream stream, PowerStats powerStats);
        public Result DeleteCustomHeroById(string id);
        public Result LoginUser(string userName, string password);
        public Result RegisterUser(string userName, string password);
    }
}