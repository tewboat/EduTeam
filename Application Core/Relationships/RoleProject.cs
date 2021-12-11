using System;
using ApplicationCore.Project;

namespace ApplicationCore
{
    public class RoleProject
    {
        public Guid ProjectGuid { get; set; }
        public Project.Project Project { get; set; }
        public TeamRole TeamRole { get; set; }
    }
}