using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using SuperHeroBackend.domain.model;
using SuperHeroBackend.domain.model.enums;
using SuperHeroBackend.domain.model.market;
using SuperHeroProject.domain.interfaces;

namespace SuperHeroBackend.infrastructure.remote
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MarketApiService : IMarketApiService
    {
        private readonly FirebaseClient firebase = new(MainApiService.BaseUrl);

        public const string Market = "market";
        private const string MarketUsers = "users";
        public const string MarketApprove = "approved";
        public const string MarketWaiting = "waiting";
        public const string MarketCancelled = "cancelled";

        public void AddHeroToMarket(MarketHero hero)
        {
            firebase
                .Child(Market)
                .Child(MarketWaiting)
                .Child(hero.Id)
                .PutAsync(hero).Wait();

            firebase
                .Child(Market)
                .Child(MarketUsers)
                .Child(hero.UserId)
                .Child(hero.Id)
                .PutAsync(hero).Wait();
        }

        public IEnumerable<MarketHero> GetAllHeroesByUserId(string userId)
        {
            var listOfMarketHeroes = firebase
                .Child(Market)
                .Child(MarketUsers)
                .Child(userId)
                .OnceAsync<MarketHero>();
            listOfMarketHeroes.Wait();
            return listOfMarketHeroes.Result.Select(i => i.Object);
        }

        public IEnumerable<MarketHero> GetAllHeroesAtMarket()
        {
            var listOfMarketHeroes = firebase
                .Child(Market)
                .Child(MarketApprove)
                .OnceAsync<MarketHero>();
            listOfMarketHeroes.Wait();
            return listOfMarketHeroes.Result.Select(i => i.Object);
        }

        public BuyHeroState BuyHeroAtMarket(User user, string heroId)
        {
            var task = firebase
                .Child(Market)
                .Child(MarketWaiting)
                .Child(heroId)
                .OnceSingleAsync<MarketHero>();
            task.Wait();
            if (task.Result == null)
            {
                return BuyHeroState.NotExist;
            }

            var price = task.Result.Price;
            return price <= user.AmountOfCoins ? BuyHeroState.Success : BuyHeroState.NotEnoughMoney;
        }
    }
}