namespace HallOfFame.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Users.ViewModels;
    using HallOfFame.Web.Common;
    using HallOfFame.Web.Controllers;

    using Microsoft.AspNet.Identity;

    [Authorize] 
    public class SettingsController : Controller
    {
        public SettingsController(IRepository<User> users)
        {
            this.Users = users;
        }

        private IRepository<User> Users { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Users.Find(userId);
            var model = Mapper.Map<UserSettingsViewModel>(user);
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserSettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.Users.Find(User.Identity.GetUserId());
                this.UpdateUserSettings(user, model);
                this.Users.SaveChanges();

                // Todo: add notification for success
                return this.RedirectToAction(ControllerNames.Index, new { controller = "Profile", area = "Users" });
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