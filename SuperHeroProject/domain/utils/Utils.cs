using System;
using System.Linq;
using FluentResults;
using SuperHeroBackend.domain.model;

namespace SuperHeroBackend.domain.utils
{
    public static class Utils
    {
        public const string ErrorMessage = "Bad connection, retry later!";

        public static string GetErrorMessage(Result result)
        {
            return result.Errors.First().Message;
        }

        public static string GetNewId()
        {
            return Guid.NewGuid().ToString();
        }

        public static User GetUser()
        {
            return new User("123456789", "Sasha Kuzevanov", "abcd", 1000);
        }

        // public static string GetUserId()
        // {
        //     return GetUser().Id;
        // }
    }
}