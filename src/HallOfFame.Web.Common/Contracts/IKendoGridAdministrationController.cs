namespace HallOfFame.Web.Common.Contracts
{
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    public interface IKendoGridAdministrationController
    {
        IEnumerable GetData();

        object GetById(object id);

        ActionResult Read([DataSourceRequest]DataSourceRequest request); 
    }
}