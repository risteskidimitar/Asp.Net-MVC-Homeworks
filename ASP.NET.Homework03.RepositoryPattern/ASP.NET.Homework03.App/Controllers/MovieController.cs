using ASP.NET.Homework03.BusinessLayer.Interfaces;
using ASP.NET.Homework03.BusinessLayer.Services;
using ASP.NET.Homework03.BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework03.App.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }

        [HttpGet("get-movie")]
        public IActionResult GetMovie(string error)
        {
            ViewBag.Error = error;
            return View();
        }

        [HttpPost("get-movie")]
        public IActionResult GetMovie(OrderDetailsVM getMovie)
        {
            var check = _movieService.MovieById(getMovie);
            if (!check) return RedirectToAction("GetMovie", new { error = "There is no movie like that try again" });
            if (!ModelState.IsValid) return RedirectToAction("GetMovie", new { error = "Fill the required information" });
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

            var check = _movieService.UploadMovie(uploadMovie);
            if (check == "admin")
            {
                TempData["Error"] = "You are admins email is not correct";
                return RedirectToAction("UploadMovie");
            }
            if (check == "movie")
            {
                TempData["Error"] = "The movie is already uploaded";
                return RedirectToAction("UploadMovie");
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "The movie was not uploaded, try again";
                return RedirectToAction("UploadMovie");
            }
            return View("UploadingComplete");
        }
    }
}
