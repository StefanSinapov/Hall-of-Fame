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

            var courses = new HashSet<Course>();

            var programmingCategory = context.Categories.First(c => c.Name == "Programming with C#");

            if (programmingCategory != null)
            {
                courses.Add(
                    new Course
                        {
                            Name = "C Sharp Programming Part 1",
                            Description = "Безплатният курс \"C# програмиране - част I\" запознава курсистите с основите на програмирането. Изучават се съвсем начални понятия от алгоритмичното програмиране, езика C#, средата за разработка Visual Studio, типове данни в програмирането, променливи и работа с тях, програмни оператори, аритметични изрази, средства за четене и писане на конзолата, условни конструкции за управление (if, if-else и switch-case) и различни видове цикли (while, do-while, for, foreach). Чрез много практика и решаване на стотици задачи се развива алгоритмичното мислене и уменията за решаване на задачи и се трупа практика при писането на програмен код и се изграждат базови умения за тестване и дебъгване.",
                            Category = programmingCategory,
                            TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/csharp-programming-part-1/"
                        });
                courses.Add(
                    new Course
                        {
                            Name = "C Sharp Programming Part 2",
                            Description = "Безплатният курс \"C# програмиране - част II\" е продължение на навлизането в основите на програмирането. Изучават се малко по-сложни, но все пак базови, концепции от програмирането като използване на масиви за обработка на редици и матрици от елементи, алгоритми върху редици и матрици, работа с методи (дефиниране и извикване, използване на параметри), бройни системи и преминаване между тях, работа с обекти от стандартната библиотека на .NET (създаване на обекти и извикване на свойства и методи), обработка на грешки и работа с изключения, работа със стрингове и обработка на текст, алгоритми за парсване на текст и работа с текстови файлове. Курсът завършва с практически изпит по програмиране.",
                            Category = programmingCategory,
                            TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/csharp-programming-part-2/"
                        });
                courses.Add(
                  new Course
                  {
                      Name = "Object Oriented Programming",
                      Description = "Безплатният курс \"Обектно-ориентирано програмиране (ООП)\" е продължение на навлизането в основите на програмирането, което следва естествено след курса C# програмиране - част II. Изучават се принципите за работа с класове и обекти, както и по-сложни концепции като абстракция, капсулация, наследяване и полиморфизъм. Курсът завършва с практически изпит по ООП.",
                      Category = programmingCategory,
                      TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/object-oriented-programming/"
                  });
                courses.Add(
                    new Course
                       {
                           Name = "High-Quality Code",
                           Description =
                               " \"Курсът Качествен програмен код\" (КПК) ще ви въведе във фундаменталните принципи и практики за изграждане на висококачествен софтуер. Чрез множество домашни и практически проекти ще овладеете индустриалните практики за писане на качествен код, техники за преработка на лош код, писане на тестваем код и автоматизирано тестване на кода чрез компонентни тестове (unit testing). Курсът се препоръчва на всички начинаещи софтуерни инженери, които искат да станат добри специалисти и да създават качествени софтуерни продукти и системи.",
                           Category = programmingCategory,
                           TelerikAcademyLink = "http://academy.telerik.com/student-courses/programming/high-quality-code/"
                       });
                courses.Add(
                    new Course
                    {
                        Name = "Data Structures & Algorithms",
                        Description =
                            "Безплатният курс \"Структури от данни и алгоритми\" е продължение на поредицата обучения по основи на програмирането и е посветен на изучаването на основните структури от данни в програмирането и базовите типове алгоритми, използвани в практиката. "
                            + "В курса се изучават основните структури от данни, използвани при разработката на софтуер: линейни структури като свързан списък, масив, стек и опашка, дървовидни структури като дървета, балансирани дървета и графи, речници, хеш-таблици и множества. Разглеждат се различни имплементации на структурите от данни и тяхната ефективност, измерена с понятието \"сложност на алгоритъм\". "
                            + "Основната цел на курса е да формира задълбочено алгоритмично мислене и алгоритмичен подход към програмирането и решаването на реални задачи. Курсът завършва с практически изпит по решаване на състезателни задачи по програмиране, включващ използването на изучаваните структури от данни и алгоритми и синтезиране на собствени алгоритмични техники. Предлага се утвърдена методология за решаване на задачи по програмиране, която се използва за решаване на задачи от практиката и в подготовката за изпита.",
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
