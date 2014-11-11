namespace HallOfFame.Web.Common.Contracts
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    public interface IKendoGridAdministrationController
    {
        IEnumerable GetData();

        T GetById<T>(object id) where T : class;

        ActionResult Read([DataSourceRequest]DataSourceRequest request); 
    }
}