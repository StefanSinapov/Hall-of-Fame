namespace HallOfFame.Web.ViewModels.Feedback
{
    using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Message { get; set; }
    }
}