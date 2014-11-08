namespace HallOfFame.Models
{
    using System;

    using HallOfFame.Data.Common.Models;

    public class Like : IAuditInfo, IDeletableEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}