namespace Application
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    
    using System;
    

    public class ApplicationContextFactory : 
        IDesignTimeDbContextFactory<ApplicationContext>,
        IDbContextFactory<ApplicationContext>

    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            return CreateDbContext();
        }

        public ApplicationContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseMySql("server=localhost;port=3306;database=edu_team;user=dev;password=mYsEcReTp$$wrd",
                new MySqlServerVersion(new Version(8, 0, 27)));
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}