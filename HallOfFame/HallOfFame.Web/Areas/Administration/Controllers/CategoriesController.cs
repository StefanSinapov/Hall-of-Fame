namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using HallOfFame.Data;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Models.Categories;
    using HallOfFame.Web.Controllers;

    public class CategoriesController : AdministrationController
    {
        private const int DefaultPageSize = 1;

        public CategoriesController()
            : this(new HallOfFameData(new HallOfFameDbContext()))
        {
        }

        public CategoriesController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index(string searchFilter, int? page, string currentFilter, string sorting = "id")
        {
            ViewBag.CurrentSort = sorting;

            ViewBag.IdSort = sorting == "Id" ? "Id descending" : "Id";
            ViewBag.NameSort = sorting == "Name" ? "Name descending" : "Name";
            ViewBag.CoursesCountSort = sorting == "CoursesCount" ? "CoursesCount descending" : "CoursesCount";

            if (searchFilter != null)
            {
                page = 1;
            }
            else
            {
                searchFilter = currentFilter;
            }

            ViewBag.SearchFilter = searchFilter;

            var selectedItems = this.Data.Categories.All();

            if (!String.IsNullOrEmpty(searchFilter))
            {
                selectedItems = selectedItems
                   .Where(x => x.Name.ToLower().Contains(searchFilter.ToLower()));
            }

            var sortedItems = selectedItems.Select(ListCategoryViewModel.ViewModel);

            int pageSize = 1;
            int pageNumber = (page ?? 1);

            return View();
        }
    }
}