using System;
using Application;
using ApplicationCore;
using ApplicationCore.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User_Interface.Models;

namespace User_Interface.Controllers
{
    using Application;
    using ApplicationCore.User;

public class TeamRoleController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext context;

        public TeamRoleController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
        }
        
        
        [HttpGet]
        public ActionResult AddTeamRole()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddTeamRole(ViewTeamRole viewTeamRole)
        {
            var newTeamRole = new TeamRole(viewTeamRole.Name, viewTeamRole.Description);
            var guid = new Guid(Request.Cookies["UserGuid"] ?? string.Empty);
            var user = context.Users.Include(u => u.PreferredRoles).GetEntityByGuid(guid);
            if (user == null)
                throw new NullReferenceException();
            user.PreferredRoles.Add(new UserRole(user, newTeamRole));
            context.SaveChanges();
            return RedirectToAction("EditUserProfile", "Profile", new {guid = guid});
        }

        public static ViewTeamRole ConvertToView(TeamRole teamRole)
        {
            return new ViewTeamRole()
            {
                Name = teamRole.Name,
                Description = teamRole.Description
            };
        }
    }
}