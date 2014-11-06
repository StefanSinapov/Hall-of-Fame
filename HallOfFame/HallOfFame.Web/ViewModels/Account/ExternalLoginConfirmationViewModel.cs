namespace HallOfFame.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [StringLength(15, MinimumLength = 5)]
        [Required]
        [Display(Name = "Username")]
        [RegularExpression(@"^[a-zA-Z]([/._]?[a-zA-Z0-9]+)+$")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
