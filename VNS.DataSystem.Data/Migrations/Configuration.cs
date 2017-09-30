using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;
using VNS.DataSystem.Data.Models;
using System;

namespace VNS.DataSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        private const string AdministratorUserName = "admin@vns.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            // Creates default admin user if no roles in the database
            this.CreateAdmin(context);
            this.CreateSampleData(context);

            // TODO: ??
            base.Seed(context);
        }

        private void CreateAdmin(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void CreateSampleData(MsSqlDbContext context)
        {
            if (!context.Visits.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var visit = new Visit()
                    {
                        Nurse = context.Users.First(x => x.UserName == AdministratorUserName),
                        Description = "Sample visit " + i,
                        Date = new DateTime(2017, 06, 01),
                        CreatedOn = DateTime.Now
                    };

                    context.Visits.Add(visit);
                }
            }
        }
    }
}
