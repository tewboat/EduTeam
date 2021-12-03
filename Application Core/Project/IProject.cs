using Infrastructure;

namespace ApplicationCore.Project
{
    using System.Collections.Generic;
    using User;

    public interface IProject : IEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        List<MemberProject> Members { get; set; }
        List<InvitationProject> Invitations { get; set; }
        List<RequestProject> Requests { get; set; }
    }
}