using ASP.NET.Homework03.BusinessLayer.Interfaces;
using ASP.NET.Homework03.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework03.App.Controllers
{
    public class OrderController : Controller

        //Dependency Injection
    {
        private readonly IJsonOrders _jsonOrders;
        public OrderController(IJsonOrders jsonOrdersService)
        {
            _jsonOrders = jsonOrdersService;
        }

        [HttpGet("Orders")]
        public IActionResult Index()
        {
            return Json(_jsonOrders.JsonOrders());
        }
    }
}
