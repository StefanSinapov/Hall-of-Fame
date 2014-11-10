namespace HallOfFame.Web.Areas.Administration.ViewModels.Courses
{
    using System;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class CourseInfoViewModel : CourseViewModel, IMapFrom<Course>
    {
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}