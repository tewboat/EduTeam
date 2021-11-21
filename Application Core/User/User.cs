namespace ApplicationCore.User
{
    using System;
    using System.Collections.Generic;
    using Project;

    public class User : IUser
    {
        public Guid Guid { get; }
        public string Nickname { get; }
        public List<IProject> Projects { get; }

        public User(Guid guid, string nickname, List<IProject> projects)
        {
            Guid = guid;
            Nickname = nickname;
            Projects = projects;
        }

        public User(string nickname) : this(Guid.NewGuid(), nickname, new List<IProject>())
        {
        }
    }
}