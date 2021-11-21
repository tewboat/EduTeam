namespace ApplicationCore.User
{
    using System.Collections.Generic;
    using Infrastructure;
    using Project;

    public interface IUser : IEntity
    {
        string Nickname { get; }
        List<IProject> Projects { get; }
    }
}