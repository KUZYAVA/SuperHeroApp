using SuperHeroBackend.domain.model;

namespace SuperHeroProject.domain.interfaces
{
    public interface IUserDatabase
    {
        public void AddUser(User user);
        public User GetUser();
        public string GetUserId();
    }
}