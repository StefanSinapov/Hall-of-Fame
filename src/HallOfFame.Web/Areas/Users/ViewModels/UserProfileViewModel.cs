namespace HallOfFame.Web.Areas.Users.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class UserProfileViewModel : BaseUserViewModel, IMapFrom<User>, IHaveCustomMappings
    {
        public DateTime DateRegistered { get; set; }

        public ICollection<ProjectInfoViewModel> Projects { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserProfileViewModel>()
                .ForMember(
                    m => m.Projects,
                    opt => opt.MapFrom(u => u.Projects.Select(p => new ProjectInfoViewModel
                                                                        {
                                                                            Name = p.Name,
                                                                            FacebookLink = p.FacebookLink,
                                                                            GitHubLink = p.GitHubLink,
                                                                            GooglePlusLink = p.GooglePlusLink,
                                                                            PhotoUrl = p.PhotoUrl,
                                                                            TeamName = p.TeamName,
                                                                            CommentsCount = p.Comments.Count,
                                                                            LikesCount = p.Likes.Count,
                                                                            Title = p.Title,
                                                                            Website = p.Website,
                                                                            Course = new CourseViewModel
                                                                                         {
                                                                                             Id = p.Course.Id,
                                                                                             Name = p.Course.Name
                                                                                         }
                                                                        })));
        }
    }
}