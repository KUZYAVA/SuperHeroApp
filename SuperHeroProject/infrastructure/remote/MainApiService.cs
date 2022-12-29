using System.Collections.Generic;
using System.IO;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using SuperHeroBackend.domain.model;
using SuperHeroBackend.domain.model.custom;
using SuperHeroBackend.domain.model.enums;
using SuperHeroProject.domain.interfaces;

namespace SuperHeroBackend.infrastructure.remote
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainApiService : IMainApiService
    {
        public const string BaseUrl = "https://superheroproject-e3e22-default-rtdb.europe-west1.firebasedatabase.app/";

        private readonly FirebaseClient firebase = new(BaseUrl);
        private readonly FirebaseStorage storage = new("superheroproject-e3e22.appspot.com");

        private const string Favourites = "favourites";
        private const string Custom = "custom";
        private const string Users = "users";
        private const string Photos = "photos";

        public void AddHeroToFavourites(string userId, FavouriteHero hero)
        {
            firebase
                .Child(Favourites)
                .Child(userId)
                .Child(hero.Id)
                .PutAsync(hero).Wait();
        }

        public IEnumerable<FavouriteHero> GetAllHeroesFromFavourites(string userId)
        {
            var listOfHeroIds = firebase
                .Child(Favourites)
                .Child(userId)
                .OnceAsync<FavouriteHero>();
            listOfHeroIds.Wait();
            return listOfHeroIds.Result.Select(i => i.Object);
        }

        public void DeleteHeroFromFavouritesById(string userId, string heroId)
        {
            firebase
                .Child(Favourites)
                .Child(userId)
                .Child(heroId)
                .DeleteAsync().Wait();
        }

        public void AddCustomHero(string userId, CustomHero hero)
        {
            firebase
                .Child(Custom)
                .Child(userId)
                .Child(hero.Id)
                .PutAsync(hero).Wait();
        }

        public void DeleteCustomHeroById(string userId, string heroId)
        {
            firebase
                .Child(Custom)
                .Child(userId)
                .Child(heroId)
                .DeleteAsync().Wait();
        }

        public IEnumerable<CustomHero> GetAllCustomHeroes(string userId)
        {
            var listOfCustomHeroes = firebase
                .Child(Custom)
                .Child(userId)
                .OnceAsync<CustomHero>();
            listOfCustomHeroes.Wait();
            return listOfCustomHeroes.Result.Select(i => i.Object);
        }

        public AuthState LoginUser(string userName, string password)
        {
            var task = firebase
                .Child(Users)
                .Child(userName)
                .OnceSingleAsync<User>();
            task.Wait();
            if (task.Result == null)
            {
                return AuthState.NotRegisterYet;
            }

            var validPassword = task.Result.Password;
            return validPassword == password ? AuthState.Success : AuthState.InvalidPassword;
        }

        public AuthState RegisterUser(User user)
        {
            var task = firebase
                .Child(Users)
                .Child(user.UserName)
                .OnceSingleAsync<User>();
            task.Wait();
            if (task.Result != null)
            {
                return AuthState.LoggedAlready;
            }

            firebase
                .Child(Users)
                .Child(user.UserName)
                .PutAsync(user).Wait();
            return AuthState.Success;
        }

        public string UploadPhoto(FileStream stream, string photoId)
        {
            var downloadUrl = storage
                .Child(Photos)
                .Child(photoId)
                .PutAsync(stream).GetAwaiter().GetResult();
            return downloadUrl;
        }
    }
}