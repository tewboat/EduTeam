using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using ApplicationCore.Project;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User_Interface.Models;

namespace User_Interface.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext context;

        private int productPage;
        private Func<User, bool> filter;
        private Func<User, object> order;
        public int PageSize = 8;

        public UsersController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            context = applicationContext;
            productPage = 1;
            filter = project => true;
            order = project => project.Nickname;
        }

        public ViewResult Users(int productPage = 1)
        {
            return View(new PageUserListView()
                {
                    Users = context.Users
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
                        TotalItems = context.Users.Count()
                    },
                    UsersFilter = new UsersFilter() { }
                }
            );
        }

        public IActionResult UserProfile(Guid guid)
        {
            var user = context.Users.GetEntityByGuid(guid);
            if (user == null)
                throw new NullReferenceException();
            return View(ConvertToView(user));
        }

        public static ViewUser ConvertToView(User user)
        {
            return new ViewUser()
            {
                Guid = user.Guid,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Nickname = user.Nickname,
                Description = user.Description,
                Email = user.Email
            };
        }
    }
}