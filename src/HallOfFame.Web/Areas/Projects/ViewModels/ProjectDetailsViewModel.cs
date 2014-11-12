namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.Web.Mvc;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class ProjectDetailsViewModel : ProjectInfoViewModel, IHaveCustomMappings
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string CourseName { get; set; }

        public new void CreateMappings(IConfiguration configuration)
        {
            base.CreateMappings(configuration);
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(m => m.CourseName, opt => opt.MapFrom(u => u.Course.Name));
        }
    }
}