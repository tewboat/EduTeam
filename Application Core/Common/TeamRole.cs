using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Project
{
    public class TeamRole : ITeamRole
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TeamRole()
        {
            
        }
        public TeamRole(string name, string description)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}