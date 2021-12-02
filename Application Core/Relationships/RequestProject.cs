namespace ApplicationCore
{
    public class RequestProject : UserProject
    {
        public RequestProject()
        {
        }

        public RequestProject(User.User user, Project.Project project) : base(user, project)
        {
        }
    }
}