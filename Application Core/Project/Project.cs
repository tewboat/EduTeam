namespace ApplicationCore.Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using User;

    [Table("projects")]
    public class Project : IProject
    {
        public Guid Guid { get; }
        public string Name { get; }
        public string Description { get; }
        public IUser Owner { get; }
        public List<IUser> Members { get; }
        public List<IUser> Invitations { get; }
        public List<IUser> Requests { get; }

        public Project(Guid guid, string name, string description, List<IUser> members, List<IUser> invitations, List<IUser> requests)
        {
            Guid = guid;
            Name = name;
            Description = description;
            Members = members;
            Invitations = invitations;
            Requests = requests;
        }

        public Project(string name, string description, List<IUser> members, List<IUser> invitations, List<IUser> requests)
            : this(Guid.NewGuid(), name, description, members, invitations, requests)
        {
        }
    }
}