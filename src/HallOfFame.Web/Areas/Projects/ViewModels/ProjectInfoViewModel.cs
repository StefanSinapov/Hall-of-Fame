namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class ProjectInfoViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public string Name { get; set; }

        [Display(Name = "Cover photo")]
        public string PhotoUrl { get; set; }

        public ICollection<UserInfoViewModel> Team { get; set; }

        public string TeamName { get; set; }

        public string Title { get; set; }

        public string GitHubLink { get; set; }

        public string FacebookLink { get; set; }

        public string GooglePlusLink { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(m => m.CommentsCount, opt => opt.MapFrom(p => p.Comments.Count));
            configuration.CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(p => p.Likes.Count));
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(
                    m => m.Team,
                    opt =>
                    opt.MapFrom(
                        u => u.Team.Select(t => new UserInfoViewModel { UserName = t.UserName, AvatarUrl = t.AvatarUrl })
                            .ToList()));
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(u => u.Likes.Count));
        }
    }
}