using Infrastructure;

namespace ApplicationCore.Project
{
    public interface ITeamRole : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}