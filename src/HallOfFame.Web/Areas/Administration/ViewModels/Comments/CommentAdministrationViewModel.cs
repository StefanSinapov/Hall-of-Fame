namespace HallOfFame.Web.Areas.Administration.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Administration.ViewModels.Base;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class CommentAdministrationViewModel : AdministrationViewModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        [Required]
        [MinLength(3), MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ProjectName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentAdministrationViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                .ForMember(m => m.ProjectName, opt => opt.MapFrom(c => c.Project.Name));
        }
    }
}