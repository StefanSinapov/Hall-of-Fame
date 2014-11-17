namespace HallOfFame.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.ViewModels.Categories;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categories;

        public HomeController(IDeletableEntityRepository<Category> categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult GetCategories()
        {
            var catModels = this.categories.All().Project().To<CategoryCoursesViewModel>().ToList();

            return this.PartialView("_CategoriesNavPartial", catModels);
        }
    }
}