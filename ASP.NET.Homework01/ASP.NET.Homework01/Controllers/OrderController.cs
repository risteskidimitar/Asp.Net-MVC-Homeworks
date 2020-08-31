using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Homework01.Controllers
{
    [Route("pizza/order")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("create-order")]
        public IActionResult GetOrder()
        {
            return View();
        }

        [HttpPost("create-order")]
        public IActionResult GetOrder(string pizzaType)
        {
           if(string.IsNullOrWhiteSpace(pizzaType)) return View();
           return RedirectToAction("Index", "Home");
        }
    }
}
