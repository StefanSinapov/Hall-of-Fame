namespace HallOfFame.Web.Areas.Users.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class BaseUserViewModel : IMapFrom<User>
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "About me")]
        [DataType(DataType.MultilineText)]
        public string AboutMe { get; set; }

        [DataType(DataType.ImageUrl)]
        public string AvatarUrl { get; set; }

        public string Website { get; set; }

        [Display(Name = "Skype name")]
        public string SkypeName { get; set; }

        [Display(Name = "Facebook profile url")]
        public string FacebookProfile { get; set; }

        [Display(Name = "Google+ profile url")]
        public string GooglePlusProfile { get; set; }

        [Display(Name = "LinkedIn profile url")]
        public string LinkedInProfile { get; set; }

        [Display(Name = "Twitter profile url")]
        public string TwitterProfile { get; set; }

        [Display(Name = "Github profile url")]
        public string GitHubProfile { get; set; }

        [Display(Name = "Telerik Academy username")]
        public string TelerikAcademyProfile { get; set; }
    }
}