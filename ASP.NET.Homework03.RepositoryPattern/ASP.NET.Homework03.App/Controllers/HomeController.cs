using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET.Homework03.App.Models;
using ASP.NET.Homework03.BusinessLayer.Interfaces;
using ASP.NET.Homework03.BusinessLayer.Services;
using ASP.NET.Homework03.BusinessLayer.ViewModels;

namespace ASP.NET.Homework03.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController()
        {
            _movieService = new MovieService();
        }

        public IActionResult Index()
        {
            List<MovieDetailsVM> moviesVM = _movieService.GetAllMovies();
            return View(moviesVM);
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
