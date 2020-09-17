using ASP.NET.Homework03.BusinessLayer.DataTransferModels;
using ASP.NET.Homework03.BusinessLayer.ViewModels;
using ASP.NET.Homework03.DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Helper
{
    public static class MapperHelper
    {
        public static List<MovieDetailsVM> MapMovieModelsToMovieDetailsVm(List<Movie> movies)
        {
            return movies.Select(m => new MovieDetailsVM
            { Id = m.Id, Duration = m.Duration, Link = m.Link, Price = m.Price, Genre = m.Genre, 
                Rating = m.Rating, ReleaseDate = m.ReleaseDate, Title = m.Title }).ToList();
        }

        public static User MapOrderDetailsVmToUserModel(OrderDetailsVM orderDetailsVM)
        {
            return new User()
            {
                FirstName = orderDetailsVM.FirstName,
                LastName = orderDetailsVM.LastName,
                Email = orderDetailsVM.Email,
                Phone = orderDetailsVM.Phone
            };
        }
        public static Movie MapUploadMovieVmToMovieModel(UploadMovieVM uploadMovieVM)
        {
            return new Movie()
            {
                Title = uploadMovieVM.Title,
                Duration = uploadMovieVM.Duration,
                Genre = uploadMovieVM.Genre,
                Link = uploadMovieVM.Link,
                HasMacedonianSubtitle = uploadMovieVM.MacedonianSubtitle,
                Price = uploadMovieVM.Price,
                Rating = uploadMovieVM.Rating,
                ReleaseDate = uploadMovieVM.ReleaseDate,
            };
        }
        public static UserDto MapUserToUserDtoModel(User user)
        {
            return new UserDto()
            {
                FullName = $"{user.FirstName} {user.FirstName}",
                Id = user.Id,
                Email = user.Email,
                Phone = user.Phone
            };
        }

        public static MovieDto MapMovieToMovieDtoModel(Movie movie)
        {
            return new MovieDto()
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Genre = movie.Genre,
                Price = movie.Price,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public static OrderMovieStatsDto MapOrderToOrderMovieStatsDtoModel(OrderMovieStatsHistory order, Movie movie, User user)
        {
            return new OrderMovieStatsDto()
            {
                OrderId = order.Id,
                Movie = MapMovieToMovieDtoModel(movie),
                User = MapUserToUserDtoModel(user)
            };

        }


    }
}
