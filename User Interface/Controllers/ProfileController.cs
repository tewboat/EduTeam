using System;
using Application;
using ApplicationCore;
using ApplicationCore.Common;
using ApplicationCore.Project;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var user = context.Users.Include(u => u.PreferredRoles).GetEntityByGuid(guid);
            if (user == null)
                throw new NullReferenceException();
            return View(UsersController.ConvertToView(user));
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
        public ActionResult AddTeamRole(ViewTeamRole viewTeamRole)
        {
            var guid = new Guid(Request.Cookies["UserGuid"] ?? string.Empty);
            var user = context.Users
                .Include(u => u.PreferredRoles)
                .GetEntityByGuid(guid);
            var role = new TeamRole(viewTeamRole.Name, viewTeamRole.Description, user);
            context.TeamRoles.Add(role);
            context.SaveChanges();
            return RedirectToAction("EditUserProfile", "Profile", new {guid = guid});
        }
    }
}