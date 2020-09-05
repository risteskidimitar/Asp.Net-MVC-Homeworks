using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET.Homework02_StoreApp.Models;
using ASP.NET.Homework02_StoreApp.Db;
using ASP.NET.Homework02_StoreApp.Models.ViewModels;

namespace ASP.NET.Homework02_StoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var movies = MovieDatabase.Movies;


            var listOfMOviesVM = new List<MovieDetailsVM>();
            foreach (var movie in movies)
            {
                var movieDetailsVM = new MovieDetailsVM()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Duration = movie.Duration,
                    Genre = movie.Genre,
                    Price = movie.Price,
                    Rating = movie.Rating,
                    ReleaseDate = movie.ReleaseDate,
                    Link = movie.Link                   
                };
                listOfMOviesVM.Add(movieDetailsVM);
            }

            return View(listOfMOviesVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
