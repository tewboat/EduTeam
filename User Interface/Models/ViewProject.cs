using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Project;

namespace User_Interface.Models
{
    public class ViewProject
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateCreation { get; set; }
        public bool IsScrumUsed { get; set; }
        public string Language { get; set; }
        public bool IsPersonalMeetingsPreferred { get; set; }
        public List<ViewUser> Members { get; set; }
        
        public List<ViewTeamRole> RequiredTeamRoles { get; set; }
    }
}