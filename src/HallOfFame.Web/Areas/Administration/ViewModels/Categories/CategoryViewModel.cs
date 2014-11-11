﻿namespace HallOfFame.Web.Areas.Administration.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Administration.ViewModels.Base;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class CategoryViewModel : AdministrationViewModel, IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}