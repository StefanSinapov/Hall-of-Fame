namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Users.ViewModels;
    using HallOfFame.Web.Controllers;

    public class UsersController : KendoGridAdministrationController
    {
        public UsersController(IRepository<User> users)
        {
            this.Users = users;
        }

        public IRepository<User> Users { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }

        public override IEnumerable GetData()
        {
            return this.Users.All().Project().To<UserSettingsViewModel>();
        }

        public override object GetById(object id)
        {
            return this.Users.Find(id);
        }
    }
}