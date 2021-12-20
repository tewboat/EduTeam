using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using ApplicationCore;
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
        private static List<Project> _projects = new List<Project>() 
                { new Project(
                    "EduTeam1", 
                    "Сервис для поиска команды для учебных проектов", 
                    Language.Rus, 
                    true, 
                    true)
                    { RequiredTeamRoles = new List<RoleProject>()
                    {
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"}},
                            new RoleProject(){TeamRole = new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}}
                    }},
                    new Project(
                        "EduTeam2", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<RoleProject>()
                    {
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}}
                    }},
                    new Project(
                        "EduTeam3", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<RoleProject>()
                    {
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}}
                    }},
                    new Project(
                        "EduTeam4", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<RoleProject>()
                    {
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}}
                    }},
                    new Project(
                        "EduTeam5", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<RoleProject>()
                    {
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}}
                    }},
                    new Project(
                        "EduTeam6", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<RoleProject>()
                    {
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"}},
                        new RoleProject(){TeamRole = new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}}
                    }}
                };
        private int productPage;
        private Func<Project, bool> filter;
        private Func<Project, object> order;
        public int PageSize = 2;
        public int PageCount => context.Projects.Count() / PageSize + context.Projects.Count() % PageSize == 0 ? 0 : 1;

        public ProjectsController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
            productPage = 1;
            filter = project => true;
            order = project => project.DateCreation;
        }
        
        
        public ViewResult Projects(int productPage = 1)
        {
            return View(new PageProjectListView()
            {
                Projects = _projects
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
                    TotalItems = _projects.Count
                },
                ProjectsFilter = new ProjectsFilter(){ }
            });
        }

        public ViewResult Project(Guid guid)
        {
            foreach (var proj in _projects)
            {
                if (guid == proj.Guid)
                    return View(ConvertToView(proj));
            }
            throw new ArgumentException("No project with this Guid");
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ViewProject p)
        {
            var project = new Project(p.Name, p.Description, Language.Rus);
            ProjectsController._projects.Add(project);
            
            
            context.Projects.Add(project);
            project.Members.Add(
                new MemberProject(
                    context.Users.GetEntityByGuid(new Guid(Request.Cookies["UserGuid"])), 
                    project));
            context.SaveChanges();
            return RedirectToAction("Project", "Projects", new {guid = project.Guid});
        }

        private ViewProject ConvertToView(Project project)
        {
            return new ViewProject()
            {
                Guid = project.Guid,
                Name = project.Name,
                Description = project.Description,
                DateCreation = project.DateCreation.ToString(),
                IsScrumUsed = project.IsScrumUsed,
                Language = project.Language.ToString(),
                RequiredTeamRoles = project.RequiredTeamRoles
                    .Select(role => new ViewTeamRole()
                    {
                        Name = role.TeamRole.Name,
                        Description = role.TeamRole.Description
                    })
                    .ToList(),
                IsPersonalMeetingsPreferred = project.IsPersonalMeetingsPreferred,
                Members = project.Members.Select(member =>
                    new ViewUser()
                    {
                        FirstName = member.User.FirstName,
                        SecondName = member.User.SecondName,
                        Nickname = member.User.Nickname,
                        Email = member.User.Email,
                        Description = member.User.Description
                    }).ToList()
            };
        }

        private bool IsProjectMatchesFilter(Project project, ProjectsFilter filter)
        {
            // TODO : Реализовать фильтрацию проектов
            return true;
        }
    }
}