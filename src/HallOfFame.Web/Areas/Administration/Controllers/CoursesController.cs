namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.ViewModels.Courses;
    using HallOfFame.Web.Controllers;

    public class CoursesController : KendoGridAdministrationController
    {
        public CoursesController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public override IEnumerable GetData()
        {
            return this.Data.Courses.All().Project().To<CourseInfoViewModel>();
        }

        public override object GetById(object id)
        {
            return this.Data.Courses.Find(id);
        }
    }
}