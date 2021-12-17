using System;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc;
using User_Interface.Models;

namespace User_Interface.Controllers
{
    public class ProfileController : Controller
    {
        
        public ViewResult EditUserProfile(Guid guid)
        {
            //var user = context.Users.GetEntityByGuid(guid);
            foreach (var user in UsersController._users)
            {
                if (guid == user.Guid)
                    return View(UsersController.ConvertToView(user));
            }
            throw new ArgumentException("No project with this Guid");
        }
    }
}