using ASP.NET.Homework02_StoreApp.Models.Domain;
using ASP.NET.Homework02_StoreApp.Models.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework02_StoreApp.Db
{
    public static class MovieDatabase
    {
        public static List<MovieStatsHistory> Orders;
        public static List<Movie> Movies;
        public static List<User> Users;

        static MovieDatabase()
        {
            Users = new List<User>()
            {
                new User()
                {
                     Id = 1,
                     FirstName= "Dimitar",
                     LastName = "Risteski",
                     Email = "risteski.dimitar@gmail.com",
                     Phone = 078123456

                },

                new User()
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Email = "bob@yahoo.com",
                    Phone = 080012312345
                }
            };
            Movies = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Title = "Casino Royale",
                    Price = 300,
                    Genre = Genre.Action,
                    MacedonianSubtitle = true,
                    ReleaseDate = 2006,
                    Rating = 8.0f,
                    Duration = 144,

                },

                new Movie()
                {
                    Id = 2,
                    Title = "The Prestige",
                    Price = 250,
                    Genre = Genre.Drama,
                    MacedonianSubtitle = false,
                    ReleaseDate = 2006,
                    Rating = 8.5f,
                    Duration = 130,
                },

                new Movie()
                {
                    Id = 3,
                    Title = "Interstellar",
                    Price = 350,
                    Genre = Genre.SciFi,
                    MacedonianSubtitle = true,
                    ReleaseDate = 2006,
                    Rating = 8.6f,
                    Duration = 169,
                }

            };

            Orders = new List<MovieStatsHistory>()
            {
                new MovieStatsHistory()
                {
                    Id = 1,
                    MovieId = 3,
                    UserId = 1

                },
                 new MovieStatsHistory()
                {
                    Id = 2,
                    MovieId = 3,
                    UserId = 2
                },

                 new MovieStatsHistory()
                {
                    Id = 3,
                    MovieId = 1,
                    UserId = 2
                }
            };
        }
    }
}
