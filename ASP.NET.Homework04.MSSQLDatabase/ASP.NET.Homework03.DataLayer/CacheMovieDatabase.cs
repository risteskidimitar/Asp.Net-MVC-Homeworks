using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer
{
    public static class CacheMovieDatabase
    {
        public static List<OrderDetails> Orders;
        public static List<Movie> Movies;
        public static List<User> Users;

        public static int MovieId;
        public static int UserId;
        public static int OrderId;

        static CacheMovieDatabase()
        {
            Users = new List<User>()
            {
                new User()
                {
                     Id = 1,
                     FirstName= "Dimitar",
                     LastName = "Risteski",
                     Email = "risteski.dimitar@gmail.com",
                     Phone = 078123456,
                     TypeOfUser = TypeOfUser.AdminUser
                     

                },

                new User()
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Email = "bob@yahoo.com",
                    Phone = 080012312345,
                    TypeOfUser = TypeOfUser.StandardUser
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
                    HasMacedonianSubtitle = true,
                    ReleaseDate = 2006,
                    Rating = 8.0f,
                    Duration = 144,
                    Link ="https://www.imdb.com/title/tt0381061/?ref_=nv_sr_srsg_3"

                },

                new Movie()
                {
                    Id = 2,
                    Title = "The Prestige",
                    Price = 250,
                    Genre = Genre.Drama,
                    HasMacedonianSubtitle = false,
                    ReleaseDate = 2006,
                    Rating = 8.5f,
                    Duration = 130,
                    Link ="https://www.imdb.com/title/tt0482571/?ref_=fn_al_tt_1"
                },

                new Movie()
                {
                    Id = 3,
                    Title = "Interstellar",
                    Price = 350,
                    Genre = Genre.SciFi,
                    HasMacedonianSubtitle = true,
                    ReleaseDate = 2006,
                    Rating = 8.6f,
                    Duration = 169,
                    Link ="https://www.imdb.com/title/tt0816692/?ref_=fn_al_tt_1"
                }

            };
            Orders = new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    Id = 1,
                    MovieId = 3,
                    UserId = 1

                },
                 new OrderDetails()
                {
                    Id = 2,
                    MovieId = 3,
                    UserId = 2
                },

                 new OrderDetails()
                {
                    Id = 3,
                    MovieId = 1,
                    UserId = 2
                }
            };
            MovieId = 3;
            UserId = 2;
            OrderId = 3;
        }
    }
}
