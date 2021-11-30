using System;
using System.Collections.Generic;
using ApplicationCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using User_Interface.Views.Home;

namespace User_Interface.Models
{
    public class ViewUser : PageModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public List<ViewProject> Projects { get; set; }
    }
}