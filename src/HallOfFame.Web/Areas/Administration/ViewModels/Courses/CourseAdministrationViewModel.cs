namespace HallOfFame.Web.Areas.Administration.ViewModels.Courses
{
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Administration.ViewModels.Base;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class CourseAdministrationViewModel : AdministrationViewModel, IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}