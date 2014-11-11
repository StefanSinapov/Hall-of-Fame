namespace HallOfFame.Web.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Common.Contracts;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Newtonsoft.Json;

    public abstract class KendoGridAdministrationController : AdministrationController, IKendoGridAdministrationController
    {
        protected KendoGridAdministrationController(IHallOfFameData data)
            : base(data)
        {
        }

        public abstract IEnumerable GetData();

        public abstract object GetById(object id);

        [HttpPost]
        public virtual ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.GetData().ToDataSourceResult(request);

            return this.Json(data);
        }

        [NonAction]
        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [NonAction]
        protected virtual T Create<T>([DataSourceRequest]DataSourceRequest request, T model)
        {
            return model;
        }

        private void ChangeEntityStateAndSave(object model, EntityState state)
        {
            var entry = this.Data.Context.Entry(model);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}