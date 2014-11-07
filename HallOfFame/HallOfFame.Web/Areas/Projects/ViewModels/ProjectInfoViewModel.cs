namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class ProjectInfoViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        // TODO: Image (add to model), team (viewModel)
        public string Name { get; set; }

        public string TeamName { get; set; }

        public string Info { get; set; }

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
        }
    }
}