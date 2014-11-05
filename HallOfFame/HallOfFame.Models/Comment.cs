namespace HallOfFame.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.DatePublished = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(300)]
        public string Content { get; set; }

        public virtual User Author { get; set; }

        public string AuthorId { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }
    }
}