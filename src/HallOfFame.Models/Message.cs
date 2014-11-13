namespace HallOfFame.Models
{
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Data.Common.Models;

    public class Message : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 1)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ConversationId { get; set; }

        public virtual Conversation Conversation { get; set; }
    }
}