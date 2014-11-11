namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Shared;

    using Microsoft.AspNet.Identity;

    public class DetailsController : Controller
    {
        public DetailsController(IRepository<Project> projects)
        {
            this.Projects = projects;
        }

        public IRepository<Project> Projects { get; set; }

        public ActionResult Index(string name)
        {
            var project = this.GetProjectByName(name).Project().To<ProjectDetailsViewModel>().FirstOrDefault();
            if (project == null)
            {
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });

                // TODO: custom not found page
                throw new HttpException((int)HttpStatusCode.NotFound, "Project not Found");
            }

            var currentUsername = this.User.Identity.GetUserName();

            if (project.Team.FirstOrDefault(m => m.UserName == currentUsername) != null)
            {
                ViewBag.IsTeamMember = true;
            }

            ViewBag.Id = project.Id;
            return this.View(project);
        }


        public ActionResult Likes(string name)
        {
            var likes = this.GetProjectByName(name).Select(m => m.Likes).Project().To<LikeViewModel>();
            return this.PartialView("_Likes", likes);
        }

        private IQueryable<Project> GetProjectByName(string name)
        {
            return this.Projects.Search(p => p.Name == name);
        }
    }
}