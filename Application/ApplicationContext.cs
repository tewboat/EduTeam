namespace Application
{
    using ApplicationCore.Project;
    using ApplicationCore.User;
    using Microsoft.EntityFrameworkCore;
    using Pomelo.EntityFrameworkCore.MySql;

    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Project> Projects { get; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}