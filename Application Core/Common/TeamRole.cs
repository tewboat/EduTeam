using System;
using ApplicationCore.Project;

namespace ApplicationCore.Common
{
    public class TeamRole : ITeamRole
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User.User User { get; set; }
        public Guid UserGuid { get; set; }
        
        public TeamRole(){}

        public TeamRole(string name, string description, User.User user)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Description = description;
            User = user;
            UserGuid = user.Guid;
        }
    }
}