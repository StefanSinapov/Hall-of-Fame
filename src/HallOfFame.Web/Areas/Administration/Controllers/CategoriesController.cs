namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Controllers.Base;
    using HallOfFame.Web.Areas.Administration.ViewModels.Categories;
    using HallOfFame.Web.Controllers;

    using Kendo.Mvc.UI;

    using Model = HallOfFame.Models.Category;
    using ViewModel = HallOfFame.Web.Areas.Administration.ViewModels.Categories.CategoryViewModel;

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

        public override T GetById<T>(object id)
        {
            return this.Data.Categories.Find(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dataModel = base.Create<Model>(model);
            if (dataModel != null)
            {
                model.Id = dataModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (model.Id != null)
                {
                    this.Data.Categories.Delete(model.Id.Value);
                }

                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}