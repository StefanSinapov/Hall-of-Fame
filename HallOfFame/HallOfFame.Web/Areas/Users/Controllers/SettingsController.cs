namespace HallOfFame.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HallOfFame.Common;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserSettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.Data.Users.Find(User.Identity.GetUserId());
                this.UpdateUserSettings(user, model);
                this.Data.SaveChanges();

                // Todo: add notification for success
                return this.RedirectToAction(GlobalConstants.Index, new { controller = "Profile", area = "Users" });
            }

            return this.View(model);
        }

        private void UpdateUserSettings(User user, UserSettingsViewModel model)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.AboutMe = model.AboutMe;
            user.Gender = model.Gender;
            user.BirthDate = model.BirthDate;
            user.Website = model.Website;
            user.SkypeName = model.SkypeName;
            user.TelerikAcademyProfile = model.TelerikAcademyProfile;
            user.FacebookProfile = model.FacebookProfile;
            user.GooglePlusProfile = model.GooglePlusProfile;
            user.LinkedInProfile = model.LinkedInProfile;
            user.TwitterProfile = model.TwitterProfile;
            user.GitHubProfile = model.GitHubProfile;
        }
    }
}