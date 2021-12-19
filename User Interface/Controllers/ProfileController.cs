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
        
        public ViewResult EditUserProfile(Guid guid)
        {
            //var user = context.Users.GetEntityByGuid(guid);
            foreach (var user in UsersController._users)
            {
                if (guid == user.Guid)
                    return View(UsersController.ConvertToView(user));
            }
            throw new ArgumentException("No project with this Guid");
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