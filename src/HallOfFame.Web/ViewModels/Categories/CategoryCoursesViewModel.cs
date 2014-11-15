namespace HallOfFame.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Administration.ViewModels.Categories;
    using HallOfFame.Web.Infrastructure.Mapping;
    using HallOfFame.Web.ViewModels.Shared;

    public class CategoryCoursesViewModel : IMapFrom<Category>// , IHaveCustomMappings
    {
        public string Name { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; }

       /* public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryCoursesViewModel>()
             .ForMember(m => m.Courses, opt => opt.MapFrom(p => p.Courses.AsQueryable().Project().To<CategoryViewModel>()));
        }*/
    }
}