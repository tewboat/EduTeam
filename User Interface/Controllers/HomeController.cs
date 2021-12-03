using System.Diagnostics;
using System.Linq;
using ApplicationCore;
using ApplicationCore.Project;
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel registration)
        {
            if ( /*ModelState.IsValid*/ context.Users.All(u => u.Email != registration.Email))
            {
                context.Users.Add(new User(
                    registration.FirstName,
                    registration.SecondName,
                    registration.Nickname,
                    registration.Email,
                    registration.Password
                ));
                context.SaveChanges();
                return View("Profile");
            }

            return View();
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
            if (ModelState.IsValid)
            {
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