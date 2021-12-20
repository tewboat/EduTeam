using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ApplicationCore;
using ApplicationCore.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User_Interface.Models;
using User_Interface.Views.Home;

namespace User_Interface.Controllers
{
    using Application;
    using ApplicationCore.User;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
        }

        public IActionResult Index()
        {
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

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("UserGuid" ?? throw new InvalidOperationException());
            return RedirectToAction("Index", "Home");
        }
    }
}