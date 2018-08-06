namespace NewsSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NewsSystem.Data;
    using NewsSystem.Models.EntityModels;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsSystemDbContext>
    {
        private const string AdminRole = "admin";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsSystemDbContext context)
        {
            if (!context.Roles.Any(role => role.Name == AdminRole))
            {
                RoleStore<IdentityRole> store = new RoleStore<IdentityRole>(context);
                RoleManager<IdentityRole> manager = new RoleManager<IdentityRole>(store);

                IdentityRole role = new IdentityRole(AdminRole);
                manager.Create(role);
            }
        }
    }
}
