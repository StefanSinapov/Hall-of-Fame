namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using HallOfFame.Data;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Controllers;

    public class CategoriesController : AdministrationController
    {
       public CategoriesController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}