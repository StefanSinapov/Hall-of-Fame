namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class ProjectInfoViewModel : BaseProjectViewModel, IMapFrom<Project>, IHaveCustomMappings
    {
        public ICollection<UserInfoViewModel> Team { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(m => m.CommentsCount, opt => opt.MapFrom(p => p.Comments.Count));
            configuration.CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(m => m.Team, opt => opt.MapFrom(u => u.Team.AsQueryable().Project().To<UserInfoViewModel>()));
            configuration.CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(u => u.Likes.Count));
        }
    }
}