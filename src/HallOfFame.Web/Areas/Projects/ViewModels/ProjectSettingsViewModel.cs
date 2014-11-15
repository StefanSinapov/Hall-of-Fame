namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectSettingsViewModel : ProjectDetailsViewModel
    {
        [Required]
        [Display(Name = "Category")]
        public new int CourseId { get; set; }

        public string AddedContributor { get; set; }
    }
}