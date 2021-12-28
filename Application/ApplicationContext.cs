using ApplicationCore.Common;

namespace Application
{
    using ApplicationCore;
    using ApplicationCore.Project;
    using ApplicationCore.User;
    using Microsoft.EntityFrameworkCore;

    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamRole> TeamRoles { get; set; }
        public DbSet<MemberProject> MemberProjects { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Guid);
            modelBuilder.Entity<Project>()
                .HasKey(project => project.Guid);
            modelBuilder.Entity<TeamRole>()
                .HasKey(tr => tr.Guid);
            modelBuilder.Entity<MemberProject>()
                .HasKey(up => new { up.UserGuid, up.ProjectGuid });
            modelBuilder.Entity<InvitationProject>()
                .HasKey(up => new { up.UserGuid, up.ProjectGuid });
            modelBuilder.Entity<RequestProject>()
                .HasKey(up => new { up.UserGuid, up.ProjectGuid });
            modelBuilder.Entity<RoleProject>()
                .HasKey(rp => rp.ProjectGuid);
            modelBuilder.Entity<MemberProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(up => up.UserGuid);
            modelBuilder.Entity<MemberProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.Members)
                .HasForeignKey(up => up.ProjectGuid);
            modelBuilder.Entity<InvitationProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.Invitations)
                .HasForeignKey(up => up.UserGuid);
            modelBuilder.Entity<InvitationProject>()
                .HasOne(up => up.Project)
                .WithMany(u => u.Invitations)
                .HasForeignKey(up => up.ProjectGuid);
            modelBuilder.Entity<RequestProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.Requests)
                .HasForeignKey(up => up.UserGuid);
            modelBuilder.Entity<RequestProject>()
                .HasOne(up => up.Project)
                .WithMany(u => u.Requests)
                .HasForeignKey(up => up.ProjectGuid);
            modelBuilder.Entity<RoleProject>()
                .HasOne(rp => rp.Project)
                .WithMany(p => p.RequiredTeamRoles)
                .HasForeignKey(rp => rp.ProjectGuid);
            modelBuilder.Entity<TeamRole>()
                .HasOne(role => role.User)
                .WithMany(u => u.PreferredRoles)
                .HasForeignKey(role => role.UserGuid);
        }
    }
}