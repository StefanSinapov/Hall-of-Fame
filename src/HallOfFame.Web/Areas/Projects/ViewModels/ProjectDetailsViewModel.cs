namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class ProjectDetailsViewModel : BaseProjectViewModel, IMapFrom<Project>, IHaveCustomMappings
    {
        // TODO: Get Comments with AJAX

        public ICollection<UserInfoViewModel> Team { get; set; }

        public int LikesCount { get; set; }

        public string CourseName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(m => m.Team, opt => opt.MapFrom(u => u.Team.Select(t => new UserInfoViewModel
                                                                                       {
                                                                                           UserName = t.UserName,
                                                                                           AvatarUrl = t.AvatarUrl
                                                                                       }).ToList()));
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(u => u.Likes.Count));

            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(m => m.CourseName, opt => opt.MapFrom(u => u.Course.Name));
        }
    }
}