using System.Linq;
using System.Threading.Tasks;
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
        private readonly ApplicationContext _context;

        public RegLogController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel registration)
        {
            if (!_context.Users.All(u => u.Email != registration.Email)) return View();
            var user = new User(
                registration.FirstName,
                registration.SecondName,
                registration.Nickname,
                registration.Email,
                registration.Password
            );
            Response.Cookies.Append("UserGuid", user.Guid.ToString());
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("UserProfile", "Users", new {guid = user.Guid});
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid) return View(); // todo вывод ошибки
            var user = _context.Users
                .FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
                return View();
            Response.Cookies.Append("UserGuid", user.Guid.ToString());
            return RedirectToAction("UserProfile", "Users", new {guid = user.Guid});
        }
    }
}