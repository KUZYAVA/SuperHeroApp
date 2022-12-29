using System.Collections.Generic;
using System.IO;
using SuperHeroBackend.domain.model;
using SuperHeroBackend.domain.model.custom;
using AuthState = SuperHeroBackend.domain.model.enums.AuthState;

namespace SuperHeroProject.domain.interfaces
{
    public interface IMainApiService
    {
        public void AddHeroToFavourites(string userId, FavouriteHero hero);
        public IEnumerable<FavouriteHero> GetAllHeroesFromFavourites(string userId);
        public void DeleteHeroFromFavouritesById(string userId, string heroId);
        public void AddCustomHero(string userId, CustomHero hero);
        public void DeleteCustomHeroById(string userId, string heroId);
        public IEnumerable<CustomHero> GetAllCustomHeroes(string userId);
        public AuthState LoginUser(string userName, string password);
        public AuthState RegisterUser(User user);
        public string UploadPhoto(FileStream stream, string photoId);
    }
}