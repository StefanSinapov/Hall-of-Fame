namespace HallOfFame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Data.Common.Models;

    public class Course : IDeletableEntity
    {
        private ICollection<Project> projects;

        public Course()
        {
            this.projects = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Project> Projects
        {
            get
            {
                return this.projects;
            }

            set
            {
                this.projects = value;
            }
        }

        public string TelerikAcademyLink { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}