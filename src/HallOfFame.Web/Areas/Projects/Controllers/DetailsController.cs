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

    using Kendo.Mvc.UI;

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
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });

                // TODO: custom not found page
                throw new HttpException((int)HttpStatusCode.NotFound, "Project not Found");
            }

            ViewBag.Id = project.Id;
            return this.View(project);
        }
    }
}