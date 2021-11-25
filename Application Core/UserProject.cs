namespace ApplicationCore
{
    using System;

    public class UserProject
    {
        public Guid UserGuid { get; set; }
        public User.User User { get; set; }
        public Guid ProjectGuid { get; set; }
        public Project.Project Project { get; set; }
    }
}