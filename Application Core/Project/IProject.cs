using Infrastructure;

namespace ApplicationCore.Project
{
    using System.Collections.Generic;
    using User;

    public interface IProject : IEntity
    {
        string Name { get; }
        string Description { get; }
        List<IUser> Members { get; }
    }
}