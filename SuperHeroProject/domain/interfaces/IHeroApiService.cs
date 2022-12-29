using System.Collections.Generic;
using SuperHeroProject.domain.model.hero;

namespace SuperHeroProject.domain.interfaces
{
    public interface IHeroApiService
    {
        public List<Hero> GetAllHeroes();

        public Hero GetHeroById(string id);
    }
}