namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Administration.ViewModels.Courses;
    using HallOfFame.Web.Controllers;

    public class CoursesController : KendoGridAdministrationController
    {
        public CoursesController(IRepository<Course> courses)
        {
            this.Courses = courses;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public IRepository<Course> Courses { get; set; }

        public override IEnumerable GetData()
        {
            return this.Courses.All().Project().To<CourseInfoViewModel>();
        }

        public override object GetById(object id)
        {
            return this.Courses.Find(id);
        }
    }
}