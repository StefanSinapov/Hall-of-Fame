﻿namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;

    using Model = HallOfFame.Models.Category;
    using ViewModel = HallOfFame.Web.Areas.Administration.ViewModels.Categories.CategoryViewModel;

    public class CategoriesController : KendoGridAdministrationController
    {
        public CategoriesController(IHallOfFameData data)
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
            if (model != null && ModelState.IsValid)
            {
                var category = this.Data.Categories.Find(model.Id);

                foreach (var courseId in category.Courses.Select(c => c.Id).ToList())
                {
                    foreach (var projectId in this.Data.Courses.Find(courseId).Projects.Select(p => p.Id))
                    {
                        foreach (var commentId in this.Data.Projects.Find(projectId).Comments.Select(c => c.Id))
                        {
                            this.Data.Comments.Delete(commentId);
                        }

                        this.Data.SaveChanges();
                        this.Data.Projects.Delete(projectId);
                    }

                    this.Data.SaveChanges();
                    this.Data.Courses.Delete(courseId);
                }

                this.Data.SaveChanges();

                this.Data.Categories.Delete(category);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .Categories
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Categories.Find(id) as T;
        }
    }
}