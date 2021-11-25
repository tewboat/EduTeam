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
        public List<UserProject> Members { get; set; }
        public List<UserProject> Invitations { get; set; }
        public List<UserProject> Requests { get; set; }
    }
}