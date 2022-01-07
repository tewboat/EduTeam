using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using ApplicationCore.Project;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User_Interface.Models;

namespace User_Interface.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        private Func<User, bool> filter;
        private Func<User, object> order;
        public int PageSize = 12;

        public UsersController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
            filter = project => true;
            order = project => project.Nickname;
        }

        public ViewResult Users(int productPage = 1)
        {
            return View(new PageUserListView()
                {
                    Users = _context.Users
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
                        TotalItems = _context.Users.Count()
                    },
                    UsersFilter = new UsersFilter() { }
                }
            );
        }

        public IActionResult UserProfile(Guid guid)
        {
            var user = _context.Users
                .GetEntity(guid);
            if (user == null)
                throw new NullReferenceException();
            return View(ConvertToView(user));
        }

        /*[HttpGet]
        public IActionResult UserInvitation()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult UserInvitation(ViewInvitation invitation)
        {
            
        }*/

        public static ViewUser ConvertToView(User user)
        {
            return new ViewUser()
            {
                Guid = user.Guid,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Nickname = user.Nickname,
                Description = user.Description,
                Email = user.Email,
                TeamRoles = user.PreferredRoles != null ? new List<ViewTeamRole>(
                    user.PreferredRoles
                        .Select(TeamRoleController.ConvertToView)) : null
            };
        }
    }
}