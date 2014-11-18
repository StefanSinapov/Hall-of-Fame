namespace HallOfFame.Web.Areas.Administration.ViewModels.Courses
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Administration.ViewModels.Base;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class CourseAdministrationViewModel : AdministrationViewModel, IMapFrom<Course>, IHaveCustomMappings
    {
        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        [UIHint("CategoryDrowDown")]
        public int CategoryId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProjectsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseAdministrationViewModel>()
                .ForMember(m => m.ProjectsCount, opt => opt.MapFrom(c => c.Projects.Count))
                .ReverseMap();
        }
    }
}