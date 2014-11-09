namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;

    public class DetailsController : Controller
    {
        public DetailsController(IRepository<Project> projects)
        {
            this.Projects = projects;
        }

        public IRepository<Project> Projects { get; set; }

        public ActionResult Index(string name)
        {
            var project = this.Projects.Search(p => p.Name == name).Project().To<ProjectDetailsViewModel>().FirstOrDefault();
            if (project == null)
            {
                return this.RedirectToAction("Index", "Home", new { area = string.Empty});

                // TODO: custom not found page
                throw new HttpException((int)HttpStatusCode.NotFound, "Project not Found");
            }

            return this.View(project);
        }
    }
}