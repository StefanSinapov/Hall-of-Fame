namespace HallOfFame.Web.Areas.Projects.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class BaseProjectViewModel
    {
        [Required]
        [Display(Name = "Name *")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]([/._]?[a-zA-Z0-9]+)+$",
            ErrorMessage = "Name must contain only Latin letters, digits, _ and .")]
        [Remote("doesProjectNameExist", "Create", HttpMethod = "POST", ErrorMessage = "Project with that name already exists. Please enter a different name.")]
        public string Name { get; set; }

        [Display(Name = "Short description")]
        [StringLength(120, ErrorMessage = "The {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string Info { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Github Link")]
        public string GitHubLink { get; set; }

        [Display(Name = "Facebook Link")]
        public string FacebookLink { get; set; }

        [Display(Name = "Google+ Link")]
        public string GooglePlusLink { get; set; }

        [Display(Name = "Team Name")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string TeamName { get; set; }
    }
}