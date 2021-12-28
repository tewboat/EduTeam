using ApplicationCore.Common;

namespace ApplicationCore.User
{
    using System;
    using System.Collections.Generic;
    using Project;

    public class User : IUser
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public List<TeamRole> PreferredRoles { get; set; }
        public List<MemberProject> Projects { get; set; }
        public List<InvitationProject> Invitations { get; set; }
        public List<RequestProject> Requests { get; set; }

        public User(string firstName, string secondName, string nickname, string email, string password,
            string description = "")
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            SecondName = secondName;
            Nickname = nickname;
            Email = email;
            Password = password;
            Description = description;
            Projects = new List<MemberProject>();
            Invitations = new List<InvitationProject>();
            Requests = new List<RequestProject>();
            PreferredRoles = new List<TeamRole>();
        }

        public User()
        {
        }
    }
}