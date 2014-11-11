namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class ProjectSettingsViewModel : CreateProjectViewModel, IMapFrom<Project>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public ICollection<UserInfoViewModel> Team { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectDetailsViewModel>()
               .ForMember(
                   m => m.Team,
                   opt =>
                   opt.MapFrom(
                       u => u.Team.Select(t => new UserInfoViewModel
                       {
                           UserName = t.UserName,
                           AvatarUrl = t.AvatarUrl
                       })
                           .ToList()));
        }
    }
}