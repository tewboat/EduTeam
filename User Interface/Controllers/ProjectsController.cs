using System;
using System.Linq;
using System.Threading.Tasks;
using Application;
using ApplicationCore;
using ApplicationCore.Project;
using ApplicationCore.Rights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User_Interface.Models;

namespace User_Interface.Controllers
{
    public class ProjectsController : Controller
    {
        public int PageSize = 6;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        private Func<Project, bool> filter;
        private Func<Project, object> order;
        
        public int PageCount => _context.Projects.Count() / PageSize + _context.Projects.Count() % PageSize == 0 ? 0 : 1;

        public ProjectsController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
            filter = project => true;
            order = project => project.DateCreation;
        }


        public ViewResult Projects(int productPage = 1)
        {
            return View(new PageProjectListView()
            {
                Projects = _context.Projects
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
                    TotalItems = _context.Projects.Count()
                },
                ProjectsFilter = new ProjectsFilter() { }
            });
        }

        public ViewResult Project(Guid guid)
        {
            if (!Request.Cookies.ContainsKey("UserGuid"))
                return View(); //todo вывод ошибки
            var user = _context.Users.GetEntity(new Guid(Request.Cookies["UserGuid"] ?? string.Empty));
            if (user == null)
                return View(); //todo вывод ошибки
            var project = _context.Projects
                .GetEntity(guid);
            if (project == null)
                throw new NullReferenceException("No project with this Guid");
            var accessLevel = _context.MemberProjects.GetMemberAccessLevel(project, user);
            if (!accessLevel.HasValue)
                return View(); //todo вывод ошибки
            return accessLevel.Value switch
            {
                AccessLevel.Visitor => View(ConvertToView(project)), //todo возвращать разные версии страницы
                AccessLevel.Member => View(ConvertToView(project)),
                AccessLevel.Moderator => View(ConvertToView(project)),
                AccessLevel.Owner => View(ConvertToView(project)),
                _ => View(ConvertToView(project)) 
            };
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
            var user = _context.Users.GetEntity(new Guid(Request.Cookies["UserGuid"] ?? string.Empty));
            if (user == null)
                return View();
            var project = new Project(p.Name, p.Description, Language.Rus);
            _context.Projects.Add(project);
            var memberProject = new MemberProject {User = user, Project = project, UserAccessLevel = AccessLevel.Owner};
            project.Members.Add(memberProject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Project", "Projects", new
            {
                guid = project.Guid
            });
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