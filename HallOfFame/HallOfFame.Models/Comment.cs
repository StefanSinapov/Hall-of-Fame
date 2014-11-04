namespace HallOfFame.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }

        public string AuthorId { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public DateTime DatePublished { get; set; }
    }
}