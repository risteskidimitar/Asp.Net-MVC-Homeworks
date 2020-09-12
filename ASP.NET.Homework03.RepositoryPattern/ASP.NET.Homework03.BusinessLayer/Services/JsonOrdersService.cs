using ASP.NET.Homework03.BusinessLayer.DataTransferModels;
using ASP.NET.Homework03.BusinessLayer.Interfaces;
using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using ASP.NET.Homework03.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Services
{
    public class JsonOrdersService : IJsonOrders
    {
       
       public readonly IMovieRepository<Movie> _movieRepository;
        public readonly IMovieRepository<User> _userRepositry;
        public readonly IMovieRepository<OrderMovieStatsHistory> _orderRepositry;

        public JsonOrdersService()
        {
            _movieRepository = new MovieRepository<Movie>();
            _userRepositry = new MovieRepository<User>();
            _orderRepositry = new MovieRepository<OrderMovieStatsHistory>();
        }
        public List<OrderMovieStatsDto> JsonOrders()
        {
            var orders = _orderRepositry.GetAll();
            var listOfOrdersDto = new List<OrderMovieStatsDto>();
            foreach (var order in orders)
            {
                var movie = _movieRepository.GetAll().FirstOrDefault(m => m.Id == order.MovieId);
                var user = _userRepositry.GetAll().FirstOrDefault(u => u.Id == order.UserId);

                var satsDto = new OrderMovieStatsDto()
                {
                    OrderId = order.Id,
                    Movie = new MovieDto()
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Duration = movie.Duration,
                        Genre = movie.Genre,
                        Price = movie.Price,
                        Rating = movie.Rating,
                        ReleaseDate = movie.ReleaseDate
                    },
                    User = new UserDto()
                    {
                        FullName = $"{user.FirstName} {user.FirstName}",
                        Id = user.Id,
                        Email = user.Email,
                        Phone = user.Phone
                    }
                };

               listOfOrdersDto.Add(satsDto);
            }
            return listOfOrdersDto;
        }
    }
}
