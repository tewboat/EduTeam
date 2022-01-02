using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore
{
    using System;

    public class UserProject
    {
        public Guid UserGuid { get; set; }
        public virtual User.User User { get; set; }
        public Guid ProjectGuid { get; set; }
        public virtual Project.Project Project { get; set; }

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