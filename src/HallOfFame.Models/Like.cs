namespace HallOfFame.Models
{
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Data.Common.Models;

    public class Like : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}