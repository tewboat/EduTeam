namespace ApplicationCore.User
{
    using System;
    using System.Collections.Generic;
    using Project;

    public class User : IUser
    {
        public Guid Guid { get; set; }
        public string Nickname { get; set; }
        public List<MemberProject> Projects { get; set; }
        public List<InvitationProject> Invitations { get; set; }
        public List<RequestProject> Requests { get; set; }

        public User(string nickname)
        {
            Guid = Guid.NewGuid();
            Nickname = nickname;
            Projects = new List<MemberProject>();
            Invitations = new List<InvitationProject>();
            Requests = new List<RequestProject>();
        }

        public User()
        {
        }
    }
}