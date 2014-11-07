namespace HallOfFame.Web.Areas.Users.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Models.Enums;

    public class UserSettingsViewModel : BaseUserViewModel
    {
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}