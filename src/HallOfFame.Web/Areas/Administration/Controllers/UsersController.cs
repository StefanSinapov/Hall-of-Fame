namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Controllers.Base;
    using HallOfFame.Web.Areas.Users.ViewModels;
    using HallOfFame.Web.Controllers;

    public class UsersController : KendoGridAdministrationController
    {
        public UsersController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public override IEnumerable GetData()
        {
            return this.Data.Users.All().Project().To<UserSettingsViewModel>();
        }

        public override T GetById<T>(object id)
        {
            return this.Data.Users.Find(id) as T;
        }
    }
}