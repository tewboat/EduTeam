using Infrastructure;

namespace ApplicationCore.Project
{
    using System.Collections.Generic;
    using User;

    public interface IProject : IEntity
    {
        string Name { get; }
        string Description { get; }
        List<MemberProject> Members { get; }
        List<InvitationProject> Invitations { get; }
        List<RequestProject> Requests { get; }
    }
}