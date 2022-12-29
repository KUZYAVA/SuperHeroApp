using System.Collections.Generic;
using SuperHeroBackend.domain.model.hero;
using SuperHeroBackend.infrastructure.model;
using SuperHeroProject.domain.model.hero;

namespace SuperHeroBackend.infrastructure
{
    public static class Mapper
    {
        public static List<Hero> ToDomain(this List<HeroResponse> response)
        {
            return response.ConvertAll(h => h.ToDomain());
        }

        public static Hero ToDomain(this HeroResponse response)
        {
            return new Hero(response.Id.ToString(), response.Name,
                response.Slug, response.PowerStats.ToDomain(), response.Appearance.ToDomain(),
                response.Biography.ToDomain(), response.Work.ToDomain(), response.Connections.ToDomain(),
                response.Images.ToDomain());
        }

        private static Work ToDomain(this WorkResponse response)
        {
            return new Work(response.Occupation, response.Base);
        }

        private static Appearance ToDomain(this AppearanceResponse response)
        {
            return new Appearance(response.Gender, response.Race,
                response.EyeColor, response.HairColor, response.Height,
                response.Weight);
        }

        private static PowerStats ToDomain(this PowerStatsResponse response)
        {
            return new PowerStats(response.Intelligence, response.Strength,
                response.Speed, response.Durability, response.Power,
                response.Combat);
        }

        private static Images ToDomain(this ImagesResponse response)
        {
            return new Images(response.Xs, response.Sm,
                response.Md, response.Lg);
        }

        private static Connections ToDomain(this ConnectionsResponse response)
        {
            return new Connections(response.GroupAffiliation, response.Relatives);
        }

        private static Biography ToDomain(this BiographyResponse response)
        {
            return new Biography(response.FullName, response.AlterEgos,
                response.Aliases, response.PlaceOfBirth, response.FirstAppearance,
                response.Publisher, response.Alignment);
        }
    }
}