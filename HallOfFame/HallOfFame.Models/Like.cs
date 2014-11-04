namespace HallOfFame.Models
{
    using System;

    public class Like
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public DateTime DateCreated { get; set; }
    }
}