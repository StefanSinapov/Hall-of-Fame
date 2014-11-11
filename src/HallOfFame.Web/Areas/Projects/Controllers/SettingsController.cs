namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Shared;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class SettingsController : Controller
    {
        public SettingsController(IRepository<Project> projects, IRepository<Course> courses)
        {
            this.Projects = projects;
            this.Courses = courses;
        }

        public IRepository<Course> Courses { get; set; }

        public IRepository<Project> Projects { get; set; }

        [HttpGet]
        public ActionResult Index(string name)
        {
            var currentUserName = this.User.Identity.GetUserName();

            var project = this.Projects
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

        private void CheckAndUpdateProject(ProjectSettingsViewModel model)
        {
            var project = this.Projects.Search(p => p.Name == model.Name).First();

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

            this.Projects.Update(project);
            this.Projects.SaveChanges();
        }

        private List<CourseViewModel> GetCourses()
        {
            return this.Courses.All().Project().To<CourseViewModel>().ToList();
        }
    }
}