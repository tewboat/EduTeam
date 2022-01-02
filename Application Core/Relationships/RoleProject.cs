using System;
using ApplicationCore.Common;
using ApplicationCore.Project;

namespace ApplicationCore
{
    public class RoleProject
    {
        public Guid ProjectGuid { get; set; }
        public virtual Project.Project Project { get; set; }
        public virtual TeamRole TeamRole { get; set; }
    }
}