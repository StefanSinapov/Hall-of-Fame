namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class ProjectDetailsViewModel : BaseProjectViewModel, IMapFrom<Project>, IHaveCustomMappings
    {
        public int CourseId { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public string CourseName { get; set; }

        public int Id { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public ICollection<UserInfoViewModel> Team { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(m => m.CourseName, opt => opt.MapFrom(u => u.Course.Name));
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
               .ForMember(m => m.Team, opt => opt.MapFrom(u => u.Team.Select(t => new UserInfoViewModel
                                                                                      {
                                                                                          FirstName = t.FirstName,
                                                                                          LastName = t.LastName,
                                                                                          AvatarUrl = t.AvatarUrl,
                                                                                          UserName = t.UserName
                                                                                      })));
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(u => u.Likes.Count(l => l.IsDeleted == false)));
        }
    }
}