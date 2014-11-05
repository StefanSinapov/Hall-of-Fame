namespace HallOfFame.Web.ViewModels.Feedback
{
    using System.ComponentModel.DataAnnotations;

    //using Resource = Resources.Feedback.ViewModels.FeedbackViewModels;

    public class FeedbackInputModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}