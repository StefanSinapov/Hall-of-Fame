namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Controllers.Base;

    using Model = HallOfFame.Models.User;
    using ViewModel = HallOfFame.Web.ViewModels.Shared.UserInfoViewModel;

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

        protected override IEnumerable GetData()
        {
            return this.Data
                .Users
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Users.Find(id) as T;
        }
    }
}