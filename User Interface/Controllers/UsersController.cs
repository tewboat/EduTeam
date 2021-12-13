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

        private static List<User> _users = new List<User>(){
            new User("Илья1", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья2", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья3", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья4", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья5", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья6", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья7", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья8", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья9", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья10", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья11", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            new User("Илья12", "Жданов", "zdravulin", "zdavulin@mail.ru", "qwerty", "Junior C# Developer в UDV"),
            };
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
            return View(
                _users
                    .Where(filter)
                    .OrderByDescending(order)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize)
                    .Select(ConvertToView)
                    .ToList()
                );
        }

        public ViewResult User(Guid guid)
        {
            foreach (var user in _users)
            {
                if (guid == user.Guid)
                    return View(ConvertToView(user));
            }
            throw new ArgumentException("No project with this Guid");
        }

        private ViewUser ConvertToView(User user)
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