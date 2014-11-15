namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.Controllers;
    using HallOfFame.Web.ViewModels.Shared;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class SettingsController : BaseController
    {
        public SettingsController(IHallOfFameData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index(string name)
        {
            var currentUserName = this.User.Identity.GetUserName();

            var project = this.Data.Projects
                    .Search(p => p.Name == name)
                    .Project().To<ProjectSettingsViewModel>()
                    .FirstOrDefault();

            if (project == null)
            {
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });

                // TODO: custom not found page
                throw new HttpException((int)HttpStatusCode.NotFound, "Project not Found");
            }

            if (project.Team.FirstOrDefault(m => m.UserName == currentUserName) == null)
            {
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });

                // TODO: custom not found page
                throw new HttpException((int)HttpStatusCode.NotFound, "Project not Found");
            }

            this.ViewBag.Courses = this.GetCourses();

            return this.View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProjectSettingsViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.CheckAndUpdateProject(model);

                return this.RedirectToAction("Index", "Details", new { area = "Projects", name = model.Name });
            }

            return this.View(model);
        }

        public JsonResult GetUsers(string text)
        {
            var usersSearch = this.Data.Users
                .All();

            if (!string.IsNullOrEmpty(text))
            {
                usersSearch = usersSearch.Where(u => u.UserName.Contains(text));
            }

            var result = usersSearch.Project().To<UserInfoViewModel>();

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        private void CheckAndUpdateProject(ProjectSettingsViewModel model)
        {
            var project = this.Data.Projects.Search(p => p.Name == model.Name).First();

            project.Description = model.Description;
            project.Title = model.Title;
            project.TeamName = model.TeamName;
            project.PhotoUrl = model.PhotoUrl;
            project.CourseId = model.CourseId;
            project.FacebookLink = model.FacebookLink;
            project.GitHubLink = model.GitHubLink;
            project.GooglePlusLink = model.GooglePlusLink;
            project.Website = model.Website;
            project.ModifiedOn = DateTime.Now;

            if (!string.IsNullOrEmpty(model.AddedContributor))
            {
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == model.AddedContributor);
                if (user != null)
                {
                    project.Team.Add(user);
                }
            }

            this.Data.Projects.Update(project);
            this.Data.SaveChanges();
        }

        private List<CourseViewModel> GetCourses()
        {
            return this.Data.Courses.All().Project().To<CourseViewModel>().ToList();
        }
    }
}