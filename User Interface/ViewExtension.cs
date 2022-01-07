
namespace User_Interface
{
    using System.Collections.Generic;
    using System.Linq;
    using ApplicationCore;
    using ApplicationCore.Common;
    using Controllers;
    using Models;

    public static class ViewExtension
    {
        public static List<ViewProject> GetViewProjects(this IEnumerable<MemberProject> projects) =>
            projects.Select(memberProject => ProjectsController.ConvertToView(memberProject.Project))
                .ToList();

        public static List<ViewTeamRole> GetViewTeamRoles(this IEnumerable<TeamRole> roles) =>
            roles.Select(role => TeamRoleController.ConvertToView(role)).ToList();
    }
}