using ApplicationCore.Rights;

namespace ApplicationCore
{
    public class MemberProject : UserProject
    {
        public AccessLevel UserAccessLevel { get; set; }
        public MemberProject(){}
        public MemberProject(User.User user, Project.Project project) : base(user, project)
        {
        }
    }
}