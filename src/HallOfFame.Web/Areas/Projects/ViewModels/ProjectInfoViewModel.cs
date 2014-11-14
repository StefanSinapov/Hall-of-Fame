namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.Linq;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class ProjectInfoViewModel : BaseProjectViewModel, IMapFrom<Project>, IHaveCustomMappings
    {
        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public CourseViewModel Course { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectInfoViewModel>()
               .ForMember(m => m.Course, opt => opt.MapFrom(u => new CourseViewModel
                                                                   {
                                                                       Id = u.Course.Id,
                                                                       Name = u.Course.Name
                                                                   }));
            configuration.CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(m => m.CommentsCount, opt => opt.MapFrom(p => p.Comments.Count));
            configuration.CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(p => p.Likes.Count(l => l.IsDeleted == false)));
        }
    }
}