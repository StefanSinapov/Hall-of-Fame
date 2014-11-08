namespace HallOfFame.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Users.ViewModels;

    public class ProfileController : Controller
    {
        private readonly IRepository<User> users;

        public ProfileController(IRepository<User> users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Index(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = this.User.Identity.Name;
            }

            var profile = this.users.All()
                    .Where(user => user.UserName == username)
                    .Project().To<UserProfileViewModel>().FirstOrDefault();

            if (profile == null)
            {
                return this.RedirectToAction("Index", "Home");

                // TODO: custom not found page
                throw new HttpException((int)HttpStatusCode.NotFound, "Profile not Found");
            }

            return this.View(profile);
        }
    }
}