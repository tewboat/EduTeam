using System;
using Application;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User_Interface.Models;

namespace User_Interface.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext context;

        public ProfileController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
        }
        
        [HttpGet]
        public ViewResult EditUserProfile(Guid guid)
        {
            var user = context.Users.GetEntityByGuid(guid);
            if (user == null)
                throw new NullReferenceException();
            return View(UsersController.ConvertToView(user));
        }

        [HttpPost]
        public IActionResult EditUserProfile(ViewUser editUser)
        {
            var guid = new Guid(Request.Cookies["UserGuid"]);
            var user = context.Users.GetEntityByGuid(guid);
            user.FirstName = editUser.FirstName;
            user.SecondName = editUser.SecondName;
            user.Nickname = editUser.Nickname;
            user.Description = editUser.Description;
            context.SaveChanges();
            editUser = UsersController.ConvertToView(context.Users.GetEntityByGuid(new Guid(Request.Cookies["UserGuid"])));
            return RedirectToAction("UserProfile", "Users", editUser);
        }

        public ActionResult UserProjects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddTeamRole()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddTeamRole(ViewTeamRole teamRole)
        {
            // TODO: Добавить роль пользователя
            
            return RedirectToAction("EditUserProfile");
        }
    }
}