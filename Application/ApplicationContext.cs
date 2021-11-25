namespace Application
{
    using ApplicationCore;
    using ApplicationCore.Project;
    using ApplicationCore.User;
    using Microsoft.EntityFrameworkCore;
    using Pomelo.EntityFrameworkCore.MySql;

    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

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
            modelBuilder.Entity<UserProject>()
                .HasKey(up => new { up.UserGuid, up.ProjectGuid });
            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(up => up.ProjectGuid);
            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.Members)
                .HasForeignKey(up => up.UserGuid);
        }
    }
}