namespace HallOfFame.Web.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using AutoMapper;

    using HallOfFame.Data.Common.Models;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.ViewModels.Base;
    using HallOfFame.Web.Common.Contracts;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public abstract class KendoGridAdministrationController : AdministrationController, IKendoGridAdministrationController
    {
        protected KendoGridAdministrationController(IHallOfFameData data)
            : base(data)
        {
        }

        public abstract IEnumerable GetData();

        public abstract T GetById<T>(object id) where T : class;

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var ads =
                this.GetData()
                .ToDataSourceResult(request);
            return this.Json(ads);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dataModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dataModel, EntityState.Added);
                return dataModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : AuditInfo
            where TViewModel : AdministrationViewModel
        {
            if (model != null && ModelState.IsValid)
            {
                var dataModel = this.GetById<TModel>(id);
                Mapper.Map(model, dataModel);
                this.ChangeEntityStateAndSave(dataModel, EntityState.Modified);
                model.ModifiedOn = dataModel.ModifiedOn;
            }
        }
        
        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        private void ChangeEntityStateAndSave(object dataModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dataModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}