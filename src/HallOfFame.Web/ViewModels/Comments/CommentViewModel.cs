namespace HallOfFame.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int ProjectId { get; set; }

        public string UserName { get; set; }

        public string UserAvatar { get; set; }

        public DateTime CommentedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                 .ForMember(m => m.CommentedOn, opt => opt.MapFrom(u => u.CreatedOn));
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(u => u.Author.UserName));
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.UserAvatar, opt => opt.MapFrom(u => u.Author.AvatarUrl));
        }
    }
}