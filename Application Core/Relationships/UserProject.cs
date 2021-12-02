using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore
{
    using System;

    public class UserProject
    {
        [Column("UserGuid")] public Guid UserGuid { get; set; }
        public User.User User { get; set; }
        [Column("ProjectGuid")] public Guid ProjectGuid { get; set; }
        public Project.Project Project { get; set; }

        public UserProject(User.User user, Project.Project project)
        {
            User = user;
            UserGuid = user.Guid;
            Project = project;
            ProjectGuid = project.Guid;
        }

        public UserProject()
        {
        }
    }
}