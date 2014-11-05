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
            this.SeedCourses(context);
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

            var courses = new HashSet<Course>();

            var programmingCategory = context.Categories.First(c => c.Name == "Programming with C#");

            if (programmingCategory != null)
            {
                courses.Add(
                    new Course
                        {
                            Name = "C Sharp Programming Part 1",
                            Description = "����������� ���� \"C# ������������ - ���� I\" ��������� ���������� � �������� �� ��������������. �������� �� ������ ������� ������� �� �������������� ������������, ����� C#, ������� �� ���������� Visual Studio, ������ ����� � ��������������, ���������� � ������ � ���, ��������� ���������, ����������� ������, �������� �� ������ � ������ �� ���������, ������� ����������� �� ���������� (if, if-else � switch-case) � �������� ������ ����� (while, do-while, for, foreach). ���� ����� �������� � �������� �� ������� ������ �� ������� �������������� ������� � �������� �� �������� �� ������ � �� ����� �������� ��� �������� �� ��������� ��� � �� ��������� ������ ������ �� �������� � ���������.",
                            Category = programmingCategory,
                            TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/csharp-programming-part-1/"
                        });
                courses.Add(
                    new Course
                        {
                            Name = "C Sharp Programming Part 2",
                            Description = "����������� ���� \"C# ������������ - ���� II\" � ����������� �� ����������� � �������� �� ��������������. �������� �� ����� ��-������, �� ��� ��� ������, ��������� �� �������������� ���� ���������� �� ������ �� ��������� �� ������ � ������� �� ��������, ��������� ����� ������ � �������, ������ � ������ (���������� � ���������, ���������� �� ���������), ������ ������� � ����������� ����� ���, ������ � ������ �� ������������ ���������� �� .NET (��������� �� ������ � ��������� �� �������� � ������), ��������� �� ������ � ������ � ����������, ������ ��� ��������� � ��������� �� �����, ��������� �� �������� �� ����� � ������ � �������� �������. ������ �������� � ����������� ����� �� ������������.",
                            Category = programmingCategory,
                            TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/csharp-programming-part-2/"
                        });
                courses.Add(
                  new Course
                  {
                      Name = "Object Oriented Programming",
                      Description = "����������� ���� \"�������-����������� ������������ (���)\" � ����������� �� ����������� � �������� �� ��������������, ����� ������ ���������� ���� ����� C# ������������ - ���� II. �������� �� ���������� �� ������ � ������� � ������, ����� � ��-������ ��������� ���� ����������, ����������, ����������� � ������������. ������ �������� � ����������� ����� �� ���.",
                      Category = programmingCategory,
                      TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/object-oriented-programming/"
                  });
                courses.Add(
                    new Course
                       {
                           Name = "High-Quality Code",
                           Description =
                               " \"������ ��������� ��������� ���\" (���) �� �� ������ ��� ��������������� �������� � �������� �� ���������� �� ��������������� �������. ���� ��������� ������� � ����������� ������� �� ��������� �������������� �������� �� ������ �� ��������� ���, ������� �� ���������� �� ��� ���, ������ �� �������� ��� � �������������� �������� �� ���� ���� ����������� ������� (unit testing). ������ �� ���������� �� ������ ��������� ��������� ��������, ����� ����� �� ������ ����� ����������� � �� �������� ���������� ��������� �������� � �������.",
                           Category = programmingCategory,
                           TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/high-quality-code/"
                       });
                courses.Add(
                    new Course
                    {
                        Name = "Data Structures & Algorithms",
                        Description =
                            "����������� ���� \"��������� �� ����� � ���������\" � ����������� �� ���������� �������� �� ������ �� �������������� � � �������� �� ����������� �� ��������� ��������� �� ����� � �������������� � �������� ������ ���������, ���������� � ����������. "
                            + "� ����� �� �������� ��������� ��������� �� �����, ���������� ��� ������������ �� �������: ������� ��������� ���� ������� ������, �����, ���� � ������, ���������� ��������� ���� �������, ����������� ������� � �����, �������, ���-������� � ���������. ���������� �� �������� ������������� �� ����������� �� ����� � ������� �����������, �������� � ��������� \"�������� �� ���������\". "
                            + "��������� ��� �� ����� � �� ������� ����������� ������������ ������� � ������������ ������ ��� �������������� � ���������� �� ������ ������. ������ �������� � ����������� ����� �� �������� �� ������������ ������ �� ������������, �������� ������������ �� ����������� ��������� �� ����� � ��������� � ����������� �� ��������� ������������ �������. �������� �� ��������� ����������� �� �������� �� ������ �� ������������, ����� �� �������� �� �������� �� ������ �� ���������� � � ������������ �� ������.",
                        Category = programmingCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/data-structures-algorithms/"
                    });
            }

            var softwareTechnologiesCategory = context.Categories.First(c => c.Name == "Software Technologies");
            if (softwareTechnologiesCategory != null)
            {
                courses.Add(
                    new Course
                    {
                        Name = "Databases",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/databases"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "Web Services and Cloud",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/web-services-and-cloud-computing"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "ASP.NET Web Forms",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/asp.net-web-forms"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "ASP.NET MVC",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/aspnet-mvc"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "Single-Page Apps with JavaScript",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/javascript-spa-applications"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "End-to-End JavaScript Apps",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://telerikacademy.com/Courses/Courses/Details/189"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "Hybrid Mobile Apps",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/hybrid-mobile-apps"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "Android Mobile Apps",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/android-mobile-apps"
                    });
                courses.Add(
                    new Course
                    {
                        Name = "iOS Mobile Apps",
                        Category = softwareTechnologiesCategory,
                        TelerikAcademyLink = "http://academy.telerik.com/student-courses/software-technologies/iphone-and-ipad-mobile-apps"
                    });
            }

            var webCategory = context.Categories.First(c => c.Name == "Web Design & Development");
            if (webCategory != null)
            {
                courses.Add(new Course
                                {
                                    Name = "HTML Fundamentals",
                                    Category = webCategory,
                                    TelerikAcademyLink = "http://academy.telerik.com/student-courses/web-design-and-ui/html-fundamentals"
                                });
                courses.Add(new Course
                                {
                                    Name = "CSS Styling",
                                    Category = webCategory,
                                    TelerikAcademyLink = "http://academy.telerik.com/student-courses/web-design-and-ui/css-styling"
                                });
                courses.Add(new Course
                                {
                                    Name = "JavaScript Fundamentals",
                                    Category = webCategory,
                                    TelerikAcademyLink = "http://academy.telerik.com/student-courses/web-design-and-ui/javascript-fundamentals"
                                });
                courses.Add(new Course
                                {
                                    Name = "JavaScript UI & DOM",
                                    Category = webCategory,
                                    TelerikAcademyLink = "http://academy.telerik.com/student-courses/web-design-and-ui/javascript-ui-dom"
                                });
                courses.Add(new Course
                                {
                                    Name = "JavaScript Applications",
                                    Category = webCategory,
                                    TelerikAcademyLink = "http://academy.telerik.com/student-courses/web-design-and-ui/javascript-applications"
                                });
            }

            foreach (var course in courses)
            {
                context.Courses.AddOrUpdate(course);
            }
        }
    }
}
