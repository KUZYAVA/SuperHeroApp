using System.Collections.Generic;
using SuperHeroBackend.infrastructure.model;

namespace SuperHeroBackend.infrastructure.db
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HeroDatabase
    {
        public bool AddFavouriteHero(HeroResponse hero)
        {
            return false;
        }

        public bool DeleteFavouriteHeroById(int id)
        {
            return false;
        }

        public List<HeroResponse> GetAllFavouriteHeroes()
        {
            return new List<HeroResponse>();
        }
    }
}