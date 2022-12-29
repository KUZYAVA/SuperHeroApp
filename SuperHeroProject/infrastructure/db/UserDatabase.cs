using System.Data;
using Microsoft.EntityFrameworkCore;
using SuperHeroBackend.domain.model;
using SuperHeroProject.domain.interfaces;

namespace SuperHeroBackend.infrastructure.db
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class UserDatabase : IUserDatabase
    {
        // public class ApplicationContext : DbContext
        // {
        //     public DbType Users {get;set; } = null!;
        //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     {
        //         optionsBuilder.UseSqlite("Data Source=user.db");
        //     }
        // }

        public void AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser()
        {
            return new User("123456789", "Sasha Kuzevanov", "abcd", 1000);
        }

        public string GetUserId()
        {
            return GetUser().Id;
        }
    }
}