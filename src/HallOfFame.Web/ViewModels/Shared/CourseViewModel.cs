namespace HallOfFame.Web.ViewModels.Shared
{
    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class CourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}