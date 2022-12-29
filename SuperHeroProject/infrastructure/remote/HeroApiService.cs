using System.Collections.Generic;
using SuperHeroBackend.infrastructure.model;
using RestSharp;
using SuperHeroBackend.domain.model.hero;
using SuperHeroProject.domain.interfaces;
using SuperHeroProject.domain.model.hero;

namespace SuperHeroBackend.infrastructure.remote
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HeroApiService : IHeroApiService
    {
        private readonly RestClient client = new("https://akabab.github.io/superhero-api/api");

        public List<Hero> GetAllHeroes()
        {
            var request = new RestRequest("all.json");
            var response = client.Execute<List<HeroResponse>>(request);
            return response.Data.ToDomain();
        }

        public Hero GetHeroById(string id)
        {
            var request = new RestRequest($"id/{id}.json");
            var response = client.Execute<HeroResponse>(request);
            return response.Data.ToDomain();
        }
    }
}