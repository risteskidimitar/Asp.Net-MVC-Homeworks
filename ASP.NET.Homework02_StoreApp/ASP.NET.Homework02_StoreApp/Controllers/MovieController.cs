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
    public class MovieController : Controller
    {
        [HttpGet("get-movie")]
        public IActionResult GetMovie(string error)
        {
            ViewBag.Error = error;
            return View();

        }

        [HttpPost("get-movie")]
        public IActionResult GetMovie(OrderDetailsVM getMovie)
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

            if (MovieDatabase.Users.SingleOrDefault(u => u.Email.ToLower().Trim() == user.Email.ToLower().Trim()) == null)
            {
                MovieDatabase.Users.Add(user);
            }
            

            var stats = new OrderMovieStatsHistory()
            {
                 Id = MovieDatabase.Orders.Count + 1,
                 MovieId = movie.Id,
                 UserId = user.Id
            };

            MovieDatabase.Orders.Add(stats);

            return View("BuyingComplete");
        }

        [HttpGet("upload-movie")]
        public IActionResult UploadMovie()
        {
            ViewData["Error"] = TempData["Error"];
            return View();
        }

        [HttpPost("upload-movie")]
        public IActionResult UploadMovie(UploadMovieVM uploadMovie)
        {
            var allUsers = MovieDatabase.Users;
            var allMovies = MovieDatabase.Movies;

            if (allUsers.FirstOrDefault(u => u.Email.ToLower().Trim() == uploadMovie.Email.ToLower().Trim()) == null)
            {
                TempData["Error"] = "You are admins email is not correct";
                return RedirectToAction("UploadMovie");
            }
            if (allMovies.FirstOrDefault(m=> m.Title.ToLower().Trim() == uploadMovie.Title.ToLower().Trim()) != null)
            {
                TempData["Error"] = "The movie is already uploaded";
                return RedirectToAction("UploadMovie");
            }

            var newMovie = new Movie()
            {
                Id = MovieDatabase.Movies.Count + 1,
                Title = uploadMovie.Title,
                Duration = uploadMovie.Duration,
                Genre = uploadMovie.Genre,
                Link = uploadMovie.Link,
                MacedonianSubtitle = uploadMovie.MacedonianSubtitle,
                Price = uploadMovie.Price,
                Rating = uploadMovie.Rating,
                ReleaseDate = uploadMovie.ReleaseDate,
            };

            allMovies.Add(newMovie);
            return View("UploadingComplete");
        }

    }
}
