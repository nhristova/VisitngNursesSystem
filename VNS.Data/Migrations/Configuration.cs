using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;
using VNS.Data.Models;
using System;

namespace VNS.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        private const string AdministratorUserName = "admin";
        private const string AdministratorEmail = "admin@vns.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        // TODO: Can we change method injection to ctor injection?
        protected override void Seed(MsSqlDbContext context)
        {
            // Creates default admin user if no roles in the database
            this.CreateAdmin(context);
            this.CreateSampleVisits(context);
            this.CreateMunicipalities(context);

            // TODO: ??
            base.Seed(context);
        }

        private void CreateAdmin(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRoleName = "Admin";
                var roleAdmin = new IdentityRole { Name = adminRoleName };
                roleManager.Create(roleAdmin);

                var userRoleName = "User";
                var roleUser = new IdentityRole { Name = userRoleName };
                roleManager.Create(roleUser);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorEmail,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, adminRoleName);
            }
        }

        private void CreateMunicipalities(MsSqlDbContext context)
        {
            if (!context.Municipalities.Any())
            {
                string[][] towns = {
                new string[] { "Shumen", "Belokopitovo", "Blagovo", "Vasil Drumevo", "Vehtovo", "Velino", "Vetrishte", "Gradishte", "Dibich", "Drumevo", "Iliia Blyskovo", "Ivanski", "Kladenec", "Konüovec", "Kostena reka", "Lozevo", "Makak", "Mytnica", "Novosel", "Ovcharovo", "Panajot Volovo", "Radko Dimitrievo", "Srednia", "Strujno", "Carev Brod", "Cherencha", "Marash", "Salmanovo" },
                new string[] { "Varbitsa", "Bozhurovo", "Biala reka", "Ivanovo", "Konevo", "Krajgorci", "Küolmen", "Lovec", "Malomir", "Mengishevo", "Metodievo", "Nova Biala Reka", "Stanianci", "Sushina", "Tushovica", "Chernookovo" },
                new string[] { "Venets", "Borci", "Boian", "Bujnovica", "Gabrica", "Dennica", "Drenci", "Izgrev", "Kap. Petko", "Osenovec", "Strahilica", "Chernoglavci", "Iasenkovo" },
                new string[] { "Hitrino", "Bojkovo", "Bliznaci", "Vyrbak", "Visoka poliana", "Dlyzhko", "Dobri Vojnikovo", "Edinakovci", "Zhivkovo", "Zvegor", "Iglika", "Kameno", "Kameniak", "Razvigorovo", "Slivak", "Stanovec", "Studenica", "Tervel", "Timarevo", "Trem", "Cherna" },
                new string[] { "Kaspichan", "Vyrbiane", "Zl. Niva", "Kalugerica", "s. Kaspichan", "Kosovo", "Kiulevcha", "Madara", "Markovo", "Mogila", "Pliska" },
                new string[] { "Novi Pazar", "Bedzhene", "Vojvoda", "Enevo", "Zhilino", "Z. Oreshe", "Izbul", "Mirovci", "Pamukchi", "Pisarevo", "Pravenci", "Preselka", "Sechishte", "St.Mihajlovski", "Stan", "Tyrnica" },
                new string[] { "Kaolinovo", "Branichevo", "Gusla", "Dojranci", "Dolina", "Zagoriche", "Kliment", "Lisi vryh", "Liatno", "Naum", "Omarchevo", "Pristoe", "Sini vir", "Sredkovec", "T. Ikonomovo", "Tykach" },
                new string[] { "Nikola Kozlevo", "Vekilski", "Vylnari", "Karavelovo", "Krasen dol", "Kriva reka", "Pet mogili", "Ruzhica", "Hyrsovo", "C. Ginchevo", "Cyrkvica" },
                new string[] { "Veliki Preslav", "Dragoevo", "Zlatar", "Imrenchevo", "Kochovo", "Milanovo", "Mokresh", "Mostich", "Osmar", "Suha Reka", "Troica", "Han Krum" },
                new string[] { "Smyadovo", "Aleksandrovo", "Bial Briag", "Veselinovo", "Zhelyd", "Kylnovo", "Novo Iankovo", "Rish", "Cherni vryh", "Iankovo" }
                };

                foreach (var row in towns)
                {
                    var muni = new Municipality()
                    {
                        Name = row[0],
                        Region = "Shumen",
                        CreatedOn = DateTime.Now
                    };

                    foreach (var townName in row)
                    {
                        muni.Towns.Add(new Town() { Name = townName, CreatedOn = DateTime.Now });
                    }

                    context.Municipalities.Add(muni);
                }
            }
        }

        private void CreateSampleVisits(MsSqlDbContext context)
        {
            if (!context.Visits.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var visit = new Visit()
                    {
                        Nurse = context.Users.First(x => x.UserName == AdministratorUserName),
                        Description = i.ToString() + " Lorem ipsum dolor sit amet, ad amet postulant explicari ius, duo enim blandit ei, eam corpora accusamus et.Ne has ridens dicunt conceptam, cu nec diam nonumes epicuri, cum virtute assentior no.Quo ex natum aliquid fabellas, labore voluptua vix te, ei vix aperiam ornatus voluptatum.Aeque malorum eos ne, quem viris legimus quo no.His quas novum nostrud ea.Prima impetus salutatus sit ea.",
                        Date = new DateTime(2017, 06, 01),
                        CreatedOn = DateTime.Now
                    };

                    context.Visits.Add(visit);
                }
            }
        }
    }
}
