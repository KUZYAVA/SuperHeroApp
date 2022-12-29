using System.Collections.Generic;
using FluentResults;
using SuperHeroProject.domain.model.hero;
using SortType = SuperHeroBackend.domain.SortType;

namespace SuperHeroProject.domain.repositories.interfaces
{
    public interface IHeroRepository
    {
        public Result<List<Hero>> GetAllHeroes();
        public Result<Hero> GetHeroById(string id);
        public List<Hero> SortHeroes(List<Hero> heroes, SortType sortType);
    }
}