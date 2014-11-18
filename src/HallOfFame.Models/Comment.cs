namespace HallOfFame.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Data.Common.Models;

    public class Comment : DeletableEntity
    {
        public Comment()
        {
            this.CreatedOn = DateTime.Now;
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
    }
}