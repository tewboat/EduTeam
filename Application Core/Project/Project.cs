namespace ApplicationCore.Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using User;
    
    public class Project : IProject
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MemberProject> Members { get; set; }
        public List<InvitationProject> Invitations { get; set; }
        public List<RequestProject> Requests { get; set; }
        public bool IsScrumUsed { get; set; }
        public Language Language { get; set; }
        public bool IsPersonalMeetingsPreferred { get; set; }
        public DateOnly DateCreation { get; set; }

        public Project()
        {
        }

        public Project(string name, string description, bool language, 
            bool isScrumUsed = false, bool isPersonalMeetingsPreferred = false)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Description = description;
            IsPersonalMeetingsPreferred = isPersonalMeetingsPreferred;
            IsScrumUsed = isScrumUsed;
            DateCreation = DateOnly.FromDateTime(DateTime.Today);
            Members = new List<MemberProject>();
            Invitations = new List<InvitationProject>();
            Requests = new List<RequestProject>();
        }
    }
    
}