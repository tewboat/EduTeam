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
        private readonly ApplicationContext _context;

        public TeamRoleController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }
        
        
        [HttpGet]
        public ActionResult AddTeamRole()
        {
            return PartialView();
        }

        
        [HttpPost]
        public async Task<ActionResult> AddTeamRole(ViewTeamRole viewTeamRole)
        {
            var guid = new Guid(Request.Cookies["UserGuid"] ?? string.Empty);
            var user = _context.Users
                .GetEntity(guid);
            var role = new TeamRole(viewTeamRole.Name, viewTeamRole.Description, user);
            _context.TeamRoles.Add(role);
            await _context.SaveChangesAsync();
            return RedirectToAction("EditUserProfile", "Profile", new {guid = guid});
        }

        public async Task<ActionResult> DeleteTeamRole(Guid teamRoleGuid)
        {
            var userGuid = new Guid(Request.Cookies["UserGuid"] ?? string.Empty);
            var teamRole = _context.TeamRoles.GetEntity(teamRoleGuid);
            if (teamRole is not null)
            {
                _context.TeamRoles.Remove(teamRole);
                await _context.SaveChangesAsync();
            }

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