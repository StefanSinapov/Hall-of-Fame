namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.ViewModels.Categories;
    using HallOfFame.Web.Controllers;

    public class CategoriesController : KendoGridAdministrationController
    {
        public CategoriesController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public override IEnumerable GetData()
        {
            return this.Data.Categories.All().OrderBy(x => x.Id).Project().To<CategoryViewModel>();
        }

        public override object GetById(object id)
        {
            return this.Data.Categories.Find(id);
        }
    }
}