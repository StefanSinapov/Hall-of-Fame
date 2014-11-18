namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Controllers.Base;

    using Model = HallOfFame.Models.Course;
    using ViewModel = HallOfFame.Web.Areas.Administration.ViewModels.Courses.CourseAdministrationViewModel;

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

        protected override IEnumerable GetData()
        {
            return this.Data
               .Courses
               .All()
               .Project()
               .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Courses.Find(id) as T;
        }
    }
}