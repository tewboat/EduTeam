namespace ApplicationCore
{
    public class MemberProject : UserProject
    {
        public MemberProject(){}
        public MemberProject(User.User user, Project.Project project) : base(user, project)
        {
        }
    }
}