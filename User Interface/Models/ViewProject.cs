using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Project;

namespace User_Interface.Models
{
    public class ViewProject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly DateCreation { get; set; }
        public bool IsScrumUsed { get; set; }
        public Language Language { get; set; }
        public bool IsPersonalMeetingsPreferred { get; set; }
        public List<ViewUser> Members { get; set; }
        public List<ViewUser> Invitations { get; set; }
        public List<ViewUser> Requests { get; set; }

        public ViewProject(Project project)
        {
            Name = project.Name;
            Description = project.Description;
            DateCreation = project.DateCreation;
            IsScrumUsed = project.IsScrumUsed;
            Language = project.Language;
            IsPersonalMeetingsPreferred = project.IsPersonalMeetingsPreferred;
            var a = project.Members.Select(member => new ViewUser(member.User));
        }
    }
}