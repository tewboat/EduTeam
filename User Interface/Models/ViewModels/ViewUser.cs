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
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public List<ViewTeamRole> TeamRoles { get; set; }
    }
}