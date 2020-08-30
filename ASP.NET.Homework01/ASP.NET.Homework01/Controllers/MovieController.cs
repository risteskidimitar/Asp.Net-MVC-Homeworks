using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Homework01.Controllers
{
    [Route("homework/movie")]
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("get-movies/{date}")]
        public IActionResult GetMovieByDate(DateTime date)
        {
            var testModel = new
            {
                Date = date,
                IsAvailable = true
            };
            return Json(testModel);
        }

        [Route("get-available/{available}")]
        public IActionResult GetMovieByAvailability(bool available)
        {
            var testModel = new
            {
                Date = "2019-05-03",
                IsAvailable = available
            };
            return Json(testModel);
        }

    }
}
