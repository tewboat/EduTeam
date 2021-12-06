using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore;
using ApplicationCore.User;
using Microsoft.AspNetCore.Mvc.RazorPages;
using User_Interface.Views.Home;

namespace User_Interface.Models
{
    public class ViewUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Discription { get; set; }
        public List<ViewProject> Projects { get; set; }

        public ViewUser(User user)
        {
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            Nickname = user.Nickname;
            Email = user.Email;
            Discription = user.Description;
        }
    }
}