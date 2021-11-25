namespace ApplicationCore.User
{
    using System;
    using System.Collections.Generic;
    using Project;

    public class User : IUser
    {
        public Guid Guid { get; set; }
        public string Nickname { get; set; }
        public List<UserProject> Projects { get; set; }

        public User(string nickname)
        {
            Guid = Guid.NewGuid();
            Nickname = nickname;
            Projects = new List<UserProject>();
        }
    }
}