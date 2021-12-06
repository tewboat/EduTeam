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

        public ProjectsController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
        }
        public int PageSize = 4;
        
        
        public ViewResult Projects(
            int productPage = 1,
            Func<Project, bool> filter = null, 
            Func<Project, object> order = null)
        {
            filter ??= _ => true;
            order ??= project => project.DateCreation;
            return View(
                context.Projects
                    .Where(filter)
                    .OrderByDescending(order)
                    .Skip((productPage - 1) * PageSize)
                    .Select(project => new ViewProject(project))
                    .ToList()
                );
        }
    }
}