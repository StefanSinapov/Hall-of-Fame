﻿namespace HallOfFame.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Administration.ViewModels.Categories;
    using HallOfFame.Web.Controllers;

    public class CategoriesController : KendoGridAdministrationController
    {
       public CategoriesController(IRepository<Category> categories)
       {
           this.Categories = categories;
       }

        private IRepository<Category> Categories { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }

        public override IEnumerable GetData()
        {
            return this.Categories.All().OrderBy(x => x.Id).Project().To<CategoryViewModel>();
        }

        public override object GetById(object id)
        {
            return this.Categories.Find(id);
        }
    }
}