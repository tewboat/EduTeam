using Infrastructure;

namespace ApplicationCore.Project
{
    using System.Collections.Generic;
    using User;

    public interface IProject : IEntity
    {
        string Name { get; }
        string Description { get; }
        IUser Owner { get; }
        List<IUser> Members { get; }
        List<IUser> Invitations { get; }
        List<IUser> Requests { get; }
    }
}