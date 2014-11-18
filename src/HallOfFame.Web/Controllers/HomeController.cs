namespace HallOfFame.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Categories;
    using HallOfFame.Web.ViewModels.Shared;

    public class HomeController : BaseController
    {
        private const int DefaultTimelineSize = 2;

        public HomeController(IHallOfFameData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult GetHomeTimeline(int skip = 0)
        {
            var viewModel = new TimelineViewModel<ProjectInfoViewModel> { CurrentCount = skip };

            var collection =
                this.Data.Projects.All()
                    .OrderByDescending(p => p.CreatedOn)
                    .Skip(viewModel.CurrentCount)
                    .Take(DefaultTimelineSize)
                    .Project()
                    .To<ProjectInfoViewModel>().ToList();

            viewModel.Collection = collection;
            viewModel.CurrentCount += DefaultTimelineSize;

            return this.PartialView("_TimelinePartial", viewModel);
        }

        [HttpGet]
        [OutputCache(Duration = 1 * 60 * 60)]
        public ActionResult GetCategories()
        {
            var catModels = this.Data.Categories.All().Project().To<CategoryCoursesViewModel>().ToList();

            return this.PartialView("_CategoriesNavPartial", catModels);
        }
    }
}