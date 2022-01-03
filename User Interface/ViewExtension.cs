
namespace User_Interface
{
    using System.Collections.Generic;
    using System.Linq;
    using ApplicationCore;
    using Controllers;
    using Models;

    public static class ViewExtension
    {
        public static List<ViewProject> GetViewProjects(this IEnumerable<MemberProject> projects) =>
            projects.Select(memberProject => ProjectsController.ConvertToView(memberProject.Project))
                .ToList();
    }
}