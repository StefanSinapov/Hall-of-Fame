namespace HallOfFame.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class CategoryCoursesViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; }
    }
}