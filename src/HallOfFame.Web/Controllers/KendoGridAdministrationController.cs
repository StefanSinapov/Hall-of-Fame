namespace HallOfFame.Web.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using HallOfFame.Web.Common.Contracts;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Newtonsoft.Json;

    public abstract class KendoGridAdministrationController : AdministrationController, IKendoGridAdministrationController
    {
        public abstract IEnumerable GetData();

        public abstract object GetById(object id);

        [HttpPost]
        public virtual ActionResult Read(DataSourceRequest request)
        {
            var data = this.GetData();
            var serializationSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(data.ToDataSourceResult(request), Formatting.None, serializationSettings);
            return this.Content(json, "application/json");
        }

        [NonAction]
        protected JsonResult GridOperation([DataSourceRequest]DataSourceRequest request, object model)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}