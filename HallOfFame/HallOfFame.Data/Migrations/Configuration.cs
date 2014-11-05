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
                                     new Category { Name = "Programming with C#", Description = "��������� �� ���� ����������� �� �� ����� ������� �������� �� ������������ � ����� C#, ������ �� ��������� ���, �������-����������� ������������, ��������� �� ����� � ���������, ���� �����. �� �� �� ����� ������������ ������ �� ����� ����� � ������� �� ���������� �� �������." },
                                     new Category { Name = "Software Technologies", Description = "� ���� ����������� �� �������� �������������� ������ � ������� ���� ����������� �������, Windows � Linux �������� �������������, ��� ������, ������� ����������, ���������� �� ������� � ������� �����. " },
                                     new Category { Name = "Web Design & Development", Description = "���������� �� ��� ������ � UI ���������� �� �� ������ �� ��������� ���������� � HTML 5, CSS 3, JavaScript � XAML. �� �� ���������� � � ���-����������� ������� �� ���������� �� ���������� ���� WordPress, Joomla!, Drupal � Sitefinity." },
                                     new Category { Name = "Quality Assurance", Description = "��������� �� �� ��������� � ��������� �������� � �������, ���������� � ������� �� ����������� �� ���������� � ���������������� �������� �� �������. ���������� � ��������� �� ���� � ������ �������� �� ������������." },
                                     new Category { Name = "Soft Skills and Business Skills", Description = "� �������� �� ���������� �� ���� ����������� � ���������� �� ������������� � ������ ������, ����� ���������� ����������� ���� ���������� ������. ��������� �� � ����������� ����������." }
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
