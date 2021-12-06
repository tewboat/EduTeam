using System.Linq;
using Application;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User_Interface.Views.Home;

namespace User_Interface.Controllers
{
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
                return RedirectToAction("Profile", "Profile");
            }

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
                return RedirectToAction("Profile", "Profile");
            }
            else
            {
                return View();
            }
        }
    }
}