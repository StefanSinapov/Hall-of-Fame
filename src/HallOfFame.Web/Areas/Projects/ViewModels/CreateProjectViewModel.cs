namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateProjectViewModel : BaseProjectViewModel
    {
        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
    }
}