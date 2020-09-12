using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Domain.Enum;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer
{
    public static class MovieDatabase<T> where T : IBaseEntity
    {
        public static List<T> AllEntities;

        static MovieDatabase()
        {
            AllEntities = new List<T>();

            var users = new List<User>()
                    {
                        new User()
                        {
                             Id = 1,
                             FirstName= "Dimitar",
                             LastName = "Risteski",
                             Email = "risteski.dimitar@gmail.com",
                             Phone = 078123456,
                             IsAdmin = true

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
            var movies = new List<Movie>()
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
                            Link = "https://www.imdb.com/title/tt0381061/?ref_=nv_sr_srsg_3"

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
                            Link = "https://www.imdb.com/title/tt0482571/?ref_=fn_al_tt_1"
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
                            Link = "https://www.imdb.com/title/tt0816692/?ref_=fn_al_tt_1"
                        }

            };
            var orders = new List<OrderMovieStatsHistory>()
                    {
                        new OrderMovieStatsHistory()
                        {
                            Id = 1,
                            MovieId = 3,
                            UserId = 1

                        },
                         new OrderMovieStatsHistory()
                        {
                            Id = 2,
                            MovieId = 3,
                            UserId = 2
                        },

                         new OrderMovieStatsHistory()
                        {
                            Id = 3,
                            MovieId = 1,
                            UserId = 2
                        }
        };

            MovieDatabase<User>.AllEntities.AddRange(users);
            MovieDatabase<Movie>.AllEntities.AddRange(movies);
            MovieDatabase<OrderMovieStatsHistory>.AllEntities.AddRange(orders);
        }

    }
}
