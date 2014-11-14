namespace HallOfFame.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Courses;

    public class CoursesController : Controller
    {
        private readonly IDeletableEntityRepository<Course> courses;

        private readonly IDeletableEntityRepository<Project> projects;

        public CoursesController(IDeletableEntityRepository<Course> courses, IDeletableEntityRepository<Project> projects)
        {
            this.courses = courses;
            this.projects = projects;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = this.courses.All().Where(course => course.Id == id)
                    .Project()
                    .To<CourseDetailsViewModel>()
                    .FirstOrDefault();

            if (model == null)
            {
                throw new HttpException(404, "Course not found");
            }

            return this.View(model);
        }

        public ActionResult GetProjectByCourse(int id, int page = 1)
        {
            var models = this.projects
                    .All()
                    .Where(p => p.CourseId == id)
                    .Project()
                    .To<ProjectInfoViewModel>().ToList();

            return this.PartialView("_ProjectsTimelinePartial", models);
        }
    }
}