namespace HallOfFame.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Users.ViewModels;
    using HallOfFame.Web.Controllers;

    public class ProfileController : BaseController
    {
        public ProfileController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = this.User.Identity.Name;
            }

            var profile = this.Data.Users.All()
                    .Where(user => user.UserName == username)
                    .Project().To<UserProfileViewModel>().FirstOrDefault();

            if (profile == null)
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Profile not Found");
            }

            return this.View(profile);
        }
    }
}