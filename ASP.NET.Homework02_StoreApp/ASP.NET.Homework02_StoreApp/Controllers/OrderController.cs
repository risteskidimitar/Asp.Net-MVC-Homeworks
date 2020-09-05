using ASP.NET.Homework02_StoreApp.Db;
using ASP.NET.Homework02_StoreApp.Models.DataAccessModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework02_StoreApp.Controllers
{
    public class OrderController : Controller
    {

        [HttpGet("Orders")]
        public IActionResult Index()
        {
            var orders = MovieDatabase.Orders;
            var listOfOrdersDto = new List<OrderMovieStatsDto>();

            foreach (var order in orders)
            {
                var movie = MovieDatabase.Movies.FirstOrDefault(m => m.Id == order.MovieId);
                var user = MovieDatabase.Users.FirstOrDefault(u => u.Id == order.UserId);

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
                        Rating =movie.Rating,
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

            return Json(listOfOrdersDto);
        }
    }
}
