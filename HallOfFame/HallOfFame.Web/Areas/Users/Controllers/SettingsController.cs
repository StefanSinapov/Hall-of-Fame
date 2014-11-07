namespace HallOfFame.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Users.ViewModels;
    using HallOfFame.Web.Controllers;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class SettingsController : BaseController
    {
        public SettingsController(IHallOfFameData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);
            var model = Mapper.Map<UserSettingsViewModel>(user);
            return this.View(model);
        }
    }
}