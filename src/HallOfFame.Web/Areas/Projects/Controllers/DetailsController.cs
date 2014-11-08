namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System.Data.Entity;
    using System.Web.Mvc;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;

    public class DetailsController : Controller
    {
        public DetailsController(IRepository<Project> projects)
        {
            this.Projects = projects;
        }

        public IRepository<Project> Projects { get; set; }
    }
}