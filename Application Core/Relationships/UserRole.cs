namespace ApplicationCore;

using System;
using Project;

public class UserRole
{
    public User.User User { get; set; }
    public TeamRole TeamRole { get; set; }
    public Guid UserGuid { get; set; }
    public Guid RoleGuid { get; set; }

    public UserRole(User.User user, TeamRole role)
    {
        User = user;
        TeamRole = role;
        UserGuid = user.Guid;
        RoleGuid = role.Guid;
    }
    
    public UserRole(){}
}
    