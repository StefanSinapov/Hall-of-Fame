namespace HallOfFame.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using HallOfFame.Common;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<HallOfFameDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HallOfFameDbContext context)
        {

            context.Configuration.LazyLoadingEnabled = true;

            this.SeedRoles(context);
            this.SeedCategories(context);
        }

        private void SeedRoles(HallOfFameDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            // Admin and Administrator Role
            if (!roleManager.RoleExists(GlobalConstants.AdministratorRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.AdministratorRoleName));
            }

            this.SeedAdminUser(userManager);

            // Moderator and Moderator Role
            if (!roleManager.RoleExists(GlobalConstants.ModeratorRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.ModeratorRoleName));
            }

            this.SeedModeratorUser(userManager);
        }

        private void SeedModeratorUser(UserManager<User> userManager)
        {
           /* var userModerator = new User { UserName = GlobalConstants.ModeratorUserName };
            userModerator.Email = userModerator.UserName;

            if (userManager.FindByName(GlobalConstants.ModeratorUserName) == null)
            {
                var result = userManager.Create(userModerator, GlobalConstants.ModeratorPassword);

                if (result.Succeeded)
                {
                    userManager.AddToRole(userModerator.Id, GlobalConstants.ModeratorRoleName);
                }
            }*/
        }

        private void SeedAdminUser(UserManager<User> userManager)
        {
            /*var user = new User { UserName = GlobalConstants.AdministratorUserName };
            user.Email = user.UserName;

            if (userManager.FindByName(GlobalConstants.AdministratorUserName) == null)
            {
                var result = userManager.Create(user, GlobalConstants.AdministratorPassword);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
                }
            }*/
        }

        private void SeedCategories(IHallOfFameDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new HashSet<Category>
                                 {
                                     new Category { Name = "Programming with C#", Description = "Курсовете от това направление ще ви дадат основни познания по програмиране и езика C#, писане на качествен код, обектно-ориентирано програмиране, структури от данни и алгоритми, бази данни. Те ще ви дадат необходимите знания за силен старт в сферата на разработка на софтуер." },
                                     new Category { Name = "Software Technologies", Description = "В това направление ще получите специализирани знания в области като операционни системи, Windows и Linux системна администрация, уеб услуги, мобилни приложения, разработка на софтуер в облачна среда. " },
                                     new Category { Name = "Web Design & Development", Description = "Обученията по уеб дизайн и UI технологии ще ви научат да създавате уебсайтове с HTML 5, CSS 3, JavaScript и XAML. Ще се запознаете и с най-популярните системи за управление на съдържание като WordPress, Joomla!, Drupal и Sitefinity." },
                                     new Category { Name = "Quality Assurance", Description = "Курсовете ще ви запознаят с основните практики и техники, използвани в процеса по осигуряване на качеството и автоматизираното тестване на софтуер. Обучението е подходящо за хора с базови познания по програмиране." },
                                     new Category { Name = "Soft Skills and Business Skills", Description = "В основата на обученията от това направление е развитието на комуникативни и бизнес умения, които надграждат придобитите вече технически знания. Курсовете са с практическа насоченост." }
                                 };

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(category);
            }
        }

        private void SeedCourses(IHallOfFameDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            // var courses = new HashSet<Course>();
        }
    }
}
