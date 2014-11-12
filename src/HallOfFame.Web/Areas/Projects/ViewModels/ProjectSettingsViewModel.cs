namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectSettingsViewModel : ProjectDetailsViewModel
    {
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
    }
}