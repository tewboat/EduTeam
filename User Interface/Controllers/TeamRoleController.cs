using System;
using System.Linq;
using System.Threading.Tasks;
using Application;
using ApplicationCore;
using ApplicationCore.Common;
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
            var guid = new Guid(Request.Cookies["UserGuid"] ?? string.Empty);
            var user = context.Users
                .Include(u => u.PreferredRoles)
                .GetEntityByGuid(guid);
            var role = new TeamRole(viewTeamRole.Name, viewTeamRole.Description, user);
            context.TeamRoles.Add(role);
            context.SaveChanges();
            return RedirectToAction("EditUserProfile", "Profile", new {guid = guid});
        }

        public ActionResult DeleteTeamRole(Guid teamRoleGuid)
        {
            var userGuid = new Guid(Request.Cookies["UserGuid"] ?? string.Empty);
            context.TeamRoles.Remove(context.TeamRoles.Where(tr => tr.Guid == teamRoleGuid).FirstOrDefault());
            context.SaveChanges();
            return RedirectToAction("EditUserProfile", "Profile", new {guid = userGuid});
        }

        public static ViewTeamRole ConvertToView(TeamRole teamRole)
        {
            return new ViewTeamRole()
            {
                Guid = teamRole.Guid,
                Name = teamRole.Name,
                Description = teamRole.Description
            };
        }
    }
}