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
    public class AdminApiService : IAdminApiService
    {
        private readonly FirebaseClient firebase = new(MainApiService.BaseUrl);

        private const string Market = MarketApiService.Market;
        private const string MarketApprove = MarketApiService.MarketApprove;
        private const string MarketWaiting = MarketApiService.MarketWaiting;
        private const string MarketCancelled = MarketApiService.MarketCancelled;

        public void ChangeMarketStateOfHero(MarketState marketState, MarketHero hero)
        {
            var marketStateChild = marketState == MarketState.Approved ? MarketApprove : MarketCancelled;
            firebase
                .Child(Market)
                .Child(marketStateChild)
                .Child(hero.Id)
                .PutAsync(hero);
        }

        public MarketHero GetHeroByIdFromWaiting(string heroId)
        {
            var taskGetHero = firebase
                .Child(Market)
                .Child(MarketWaiting)
                .Child(heroId)
                .OnceSingleAsync<MarketHero>();
            taskGetHero.Wait();
            return taskGetHero.Result;
        }

        public void DeleteHeroByIdFromWaiting(string heroId)
        {
            var taskDeleteHero = firebase
                .Child(Market)
                .Child(MarketWaiting)
                .Child(heroId)
                .DeleteAsync();
            taskDeleteHero.Wait();
        }
    }
}