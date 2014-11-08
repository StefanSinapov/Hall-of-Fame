namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Controllers;

    public class CategoriesController : AdministrationController
    {
       public CategoriesController(IRepository<Category> categories)
       {
           this.Categories = categories;
       }

        private IRepository<Category> Categories { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}