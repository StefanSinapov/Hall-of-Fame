namespace HallOfFame.Web.ViewModels.Courses
{
    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class CourseDetailsViewModel : IMapFrom<Course>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    
        public string TelerikAcademyLink { get; set; }

        public int ProjectsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseDetailsViewModel>()
               .ForMember(m => m.ProjectsCount, opt => opt.MapFrom(p => p.Projects.Count));
        }
    }
}