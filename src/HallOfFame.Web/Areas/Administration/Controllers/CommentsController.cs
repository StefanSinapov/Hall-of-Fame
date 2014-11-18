namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;

    using Model = HallOfFame.Models.Comment;
    using ViewModel = HallOfFame.Web.Areas.Administration.ViewModels.Comments.CommentAdministrationViewModel;

    public class CommentsController : KendoGridAdministrationController
    {
        public CommentsController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
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
            var comment = this.Data.Comments.Find(model.Id);

            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .Comments
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Comments.Find(id) as T;
        }
    }
}