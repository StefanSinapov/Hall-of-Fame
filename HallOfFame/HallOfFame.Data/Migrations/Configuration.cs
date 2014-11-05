namespace HallOfFame.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using HallOfFame.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HallOfFameDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HallOfFameDbContext context)
        {
            this.SeedCategories(context);
        }

        private void SeedCategories(HallOfFameDbContext context)
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
    }
}
