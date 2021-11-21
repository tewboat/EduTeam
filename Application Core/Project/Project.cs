namespace ApplicationCore.Project
{
    using System;
    using System.Collections.Generic;
    using User;

    public class Project : IProject

    {
        public Guid Guid { get; }
        public string Name { get; }
        public string Description { get; }
        public List<IUser> Members { get; }

        public Project(Guid guid, string name, string description, List<IUser> members)
        {
            Guid = guid;
            Name = name;
            Description = description;
            Members = members;
        }

        public Project(string name, string description, List<IUser> members)
            : this(Guid.NewGuid(), name, description, members)
        {
        }
    }
}