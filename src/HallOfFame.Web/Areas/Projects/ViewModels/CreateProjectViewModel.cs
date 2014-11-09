namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateProjectViewModel : BaseProjectViewModel
    {
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
    }
}