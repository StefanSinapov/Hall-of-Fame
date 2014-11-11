namespace HallOfFame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Data.Common.Models;

    public class Category : DeletableEntity
    {
        private ICollection<Course> courses;

        public Category()
        {
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }
    }
}