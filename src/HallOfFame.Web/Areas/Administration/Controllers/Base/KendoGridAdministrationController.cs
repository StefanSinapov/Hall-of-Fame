namespace HallOfFame.Web.Areas.Administration.Controllers.Base
{
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using AutoMapper;

    using HallOfFame.Data.Contracts;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public abstract class KendoGridAdministrationController : AdministrationController
    {
        protected KendoGridAdministrationController(IHallOfFameData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]
                                 DataSourceRequest request)
        {
            var data = this.GetData()
                           .ToDataSourceResult(request);

            return this.Json(data);
        }

        protected abstract IEnumerable GetData();

        protected abstract T GetById<T>(object id) where T : class;

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dataModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dataModel, EntityState.Added);
                return dataModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : class
            where TViewModel : class
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dataModel = this.GetById<TModel>(id);
                Mapper.Map(model, dataModel);
                this.ChangeEntityStateAndSave(dataModel, EntityState.Modified);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest] DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        protected override IAsyncResult BeginExecute(
            System.Web.Routing.RequestContext requestContext,
            AsyncCallback callback,
            object state)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            return base.BeginExecute(requestContext, callback, state);
        }

        private void ChangeEntityStateAndSave(object dataModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dataModel);
            entry.State = state;
            this.Data.SaveChanges();
        }     
    }
}