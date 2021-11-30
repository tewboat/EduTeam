﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        private ApplicationContextFactory contextFactory = new ();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            if ( true /*ModelState.IsValid*/) {
                //TODO: add the user to the database
                return View("Profile");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid) {
                //TODO: verify the password is correct
                return View("Profile");
            }
            else
            {
                return View();
            }
        }
    }
}