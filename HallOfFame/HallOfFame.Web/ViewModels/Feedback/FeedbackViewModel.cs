namespace HallOfFame.Web.ViewModels.Feedback
{
    using System.ComponentModel.DataAnnotations;

    //using Resource = Resources.Feedback.ViewModels.FeedbackViewModels;

    public class FeedbackViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        [Required(ErrorMessage = "{0} is required")]
        public string Message { get; set; }
    }
}