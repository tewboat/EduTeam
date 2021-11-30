using System;
using System.Collections.Generic;

namespace User_Interface.Models
{
    public class ViewProject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ViewUser> Members { get; set; }
        public List<ViewUser> Invitations { get; set; }
        public List<ViewUser> Requests { get; set; }
    }
}