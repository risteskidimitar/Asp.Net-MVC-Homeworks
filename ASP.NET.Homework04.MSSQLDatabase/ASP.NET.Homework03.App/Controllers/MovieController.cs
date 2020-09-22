using ASP.NET.Homework03.BusinessLayer.Helper;
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

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        //TODO: Check
        [HttpGet("get-movie")]
        public IActionResult GetMovie(string error)
        {
            ViewBag.Error = error;
            return View();
        }

        [HttpPost("get-movie")]
        public IActionResult GetMovie(OrderDetailsVM getMovie)
        {
            ResultsWrapperHelper helper = _movieService.MovieById(getMovie);
            if (!string.IsNullOrEmpty(helper.Message)) return RedirectToAction("GetMovie", new { error = helper.Message });
            if (!ModelState.IsValid) return View("GetMovie", getMovie);
         
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
            if (!ModelState.IsValid) return View("UploadMovie", uploadMovie);

            ResultsWrapperHelper helper = _movieService.UploadMovie(uploadMovie);
        
            if (!string.IsNullOrEmpty(helper.Message)) 
            {
                TempData["Error"] = helper.Message;
                return RedirectToAction("UploadMovie");
            }
          

            return View("UploadingComplete");
        }
    }
}
