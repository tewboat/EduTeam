using System;
using System.Collections.Generic;
using System.Linq;
using Application;
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
        private List<Project> _projects;
        private int productPage;
        private Func<Project, bool> filter;
        private Func<Project, object> order;

        public ProjectsController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
            _projects = new List<Project>() 
                { new Project(
                    "EduTeam", 
                    "Сервис для поиска команды для учебных проектов", 
                    Language.Rus, 
                    true, 
                    true)
                    { RequiredTeamRoles = new List<TeamRole>()
                    {
                        new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"},
                        new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"},
                        new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}
                    }},
                    new Project(
                        "EduTeam_2", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<TeamRole>()
                    {
                        new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"},
                        new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"},
                        new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}
                    }},
                    new Project(
                        "EduTeam_2", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<TeamRole>()
                    {
                        new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"},
                        new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"},
                        new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}
                    }},
                    new Project(
                        "EduTeam_2", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<TeamRole>()
                    {
                        new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"},
                        new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"},
                        new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}
                    }},
                    new Project(
                        "EduTeam_2", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<TeamRole>()
                    {
                        new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"},
                        new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"},
                        new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}
                    }},
                    new Project(
                        "EduTeam_2", 
                        "Сервис для поиска команды для учебных проектов", 
                        Language.Rus, 
                        true, 
                        true)
                    { RequiredTeamRoles = new List<TeamRole>()
                    {
                        new TeamRole(){Name = "Дизайнер", Description = "Дизайн веб-сервиса, макет в фигме"},
                        new TeamRole(){Name = "Верстальщик сайта", Description = "Вёрстка сайта в соответствии с макетом"},
                        new TeamRole(){Name = "Бэкендер C#", Description = "Работа с базами данных"}
                    }}
                };
            productPage = 1;
            filter = project => true;
            order = project => project.DateCreation;
        }
        public int PageSize = 4;
        
        
        public ViewResult Projects(
            int productPage = 1)
        {
            return View(
                _projects
                    .Where(filter)
                    .OrderByDescending(order)
                    .Skip((productPage - 1) * PageSize)
                    .Select(project =>
                        new ViewProject()
                        {
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
                                    Discription = member.User.Description
                                }).ToList()})
                    .ToList()
                );
        }

        [HttpPost]
        public ViewResult Project(ViewProject project)
        {
            return View(project);
        }
    }
}