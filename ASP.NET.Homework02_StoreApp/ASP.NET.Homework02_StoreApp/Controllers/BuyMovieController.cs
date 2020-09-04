using ASP.NET.Homework02_StoreApp.Db;
using ASP.NET.Homework02_StoreApp.Models.Domain;
using ASP.NET.Homework02_StoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework02_StoreApp.Controllers
{
    public class BuyMovieController:Controller
    {
        [HttpGet("get-movie")]
        public IActionResult GetMovie(string error)
        {
            ViewBag.Error = error;
            return View();

        }

        [HttpPost("get-movie")]
        public IActionResult GetMovie(GetMovie getMovie)
        {
            var movie = MovieDatabase.Movies.FirstOrDefault(m => m.Id == getMovie.IdOfMovie);
            if (movie == null)
            {
                return RedirectToAction("GetMovie", new { error = "There is no movie like that try again" });
            }

            var user = new User()
            {
                Id = MovieDatabase.Users.Count + 1,
                FirstName = getMovie.FirstName,
                LastName = getMovie.LastName,
                Email = getMovie.Email,
                Phone = getMovie.Phone
            };
            MovieDatabase.Users.Add(user);

            var stats = new MovieStatsHistory()
            {
                Id = MovieDatabase.Orders.Count + 1,
                 MovieId = movie.Id,
                 UserId = user.Id
            };

            MovieDatabase.Orders.Add(stats);

            return View("BuyingComplete");
        }
    }
}
