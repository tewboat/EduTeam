using System.Linq;
using Application;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User_Interface.Views.Home;

namespace User_Interface.Controllers
{
    using System;

    public class RegLogController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext context;

        public RegLogController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel registration)
        {
            if (!context.Users.All(u => u.Email != registration.Email)) return View();
            var newUser = new User(
                registration.FirstName,
                registration.SecondName,
                registration.Nickname,
                registration.Email,
                registration.Password
            );
            context.Users.Add(newUser);
            context.SaveChanges();
            return RedirectToAction("", "Users", newUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid) return View();
            var user = context.Users
                .FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
                return View();
            Response.Cookies.Append("UserGuid", user.Guid.ToString());
            return RedirectToAction("UserProfile", "Users", new {guid = user.Guid});
        }
    }
}