namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;

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
            this.PopulateCategoris();

            return this.View();
        }
      
        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dataModel = base.Create<Model>(model);
            if (dataModel != null)
            {
                model.Id = dataModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var course = this.Data.Courses.Find(model.Id);

            foreach (var projectId in course.Projects.Select(p => p.Id).ToList())
            {
                foreach (var commentId in this.Data.Projects.Find(projectId).Comments.Select(c => c.Id))
                {
                    this.Data.Comments.Delete(commentId);
                }

                this.Data.SaveChanges();
                foreach (var likeId in this.Data.Projects.Find(projectId).Likes.Select(l => l.Id))
                {
                    this.Data.Likes.Delete(likeId);
                }

                this.Data.SaveChanges();
                this.Data.Projects.Delete(projectId);
            }

            this.Data.SaveChanges();

            this.Data.Courses.Delete(course);
            this.Data.SaveChanges();

            return this.GridOperation(model, request);
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

        private void PopulateCategoris()
        {
            var categories = this.Data.Categories.All()
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                });

            this.ViewBag.Categories = categories;
        }
    }
}