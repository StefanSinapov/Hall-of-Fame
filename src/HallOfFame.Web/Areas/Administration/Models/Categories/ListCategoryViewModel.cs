namespace HallOfFame.Web.Areas.Administration.Models.Categories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using HallOfFame.Models;

    public class ListCategoryViewModel
    {
        public static Expression<Func<Category, ListCategoryViewModel>> ViewModel
        {
            get
            {
                return course => new ListCategoryViewModel
                                {
                                    Id = course.Id,
                                    Name = course.Name,
                                    CoursesCount = course.Courses.Count()
                                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        // public string Description { get; set; }
        public int CoursesCount { get; set; }
    }
}