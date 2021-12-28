using System;
using System.Collections.Generic;
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
using User_Interface.Views.Home;

namespace User_Interface.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext context;
        private Func<Project, bool> filter;
        private Func<Project, object> order;
        public int PageSize = 6;
        public int PageCount => context.Projects.Count() / PageSize + context.Projects.Count() % PageSize == 0 ? 0 : 1;

        public ProjectsController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
            filter = project => true;
            order = project => project.DateCreation;
        }
        
        
        public ViewResult Projects(int productPage = 1)
        {
            return View(new PageProjectListView()
            {
                Projects = context.Projects
                    .Include(p => p.RequiredTeamRoles)
                    .Where(filter)
                    .OrderByDescending(order)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize)
                    .Select(ConvertToView)
                    .ToList(),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = context.Projects.Count()
                },
                ProjectsFilter = new ProjectsFilter(){ }
            });
        }
        
        public ViewResult Project(Guid guid)
        {
            var project = context.Projects
                .Include(p => p.Members)
                .Include(p => p.RequiredTeamRoles)
                .GetEntityByGuid(guid);
            for (int i = 0; i < project.Members.Count; i++)
                project.Members[i].User = context.Users
                    .GetEntityByGuid(project.Members[i].UserGuid);
            if (project == null)
                throw new NullReferenceException("No project with this Guid");
            return View(ConvertToView(project));
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(ViewProject p)
        {
            if (!Request.Cookies.ContainsKey("UserGuid"))
                return View();
            var user = context.Users.GetEntityByGuid(new Guid(Request.Cookies["UserGuid"] ?? string.Empty));
            if (user == null)
                return View();
            var project = new Project(p.Name, p.Description, Language.Rus);
            context.Projects.Add(project);
            project.Members.Add(
                new MemberProject(
                    user, 
                    project));
            await context.SaveChangesAsync();
            return RedirectToAction("Project", "Projects", new {guid = project.Guid});
        }

        public static ViewProject ConvertToView(Project project)
        {
            return new ViewProject()
            {
                Guid = project.Guid,
                Name = project.Name,
                Description = project.Description,
                DateCreation = project.DateCreation.ToString(),
                IsScrumUsed = project.IsScrumUsed,
                Language = project.Language.ToString(),
                RequiredTeamRoles = project.RequiredTeamRoles?
                    .Select(role => TeamRoleController.ConvertToView(role.TeamRole))
                    .ToList(),
                IsPersonalMeetingsPreferred = project.IsPersonalMeetingsPreferred,
                Members = project.Members?.Select(member => UsersController.ConvertToView(member.User))
                    .ToList()
            };
        }

        private bool IsProjectMatchesFilter(Project project, ProjectsFilter filter)
        {
            // TODO : Реализовать фильтрацию проектов
            return true;
        }
    }
}