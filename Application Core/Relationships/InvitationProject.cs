namespace ApplicationCore
{
    public class InvitationProject : UserProject
    {
        public InvitationProject()
        {
        }

        public InvitationProject(User.User user, Project.Project project) : base(user, project)
        {
        }
    }
}