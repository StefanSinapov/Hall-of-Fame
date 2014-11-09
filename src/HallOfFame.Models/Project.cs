namespace HallOfFame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using HallOfFame.Data.Common.Models;

    public class Project : IAuditInfo, IDeletableEntity
    {
        private ICollection<User> team;

        private ICollection<Comment> comments;

        private ICollection<Like> likes;

        public Project()
        {
            this.team = new HashSet<User>();
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(120)]
        public string Info { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public string GitHubLink { get; set; }

        public string FacebookLink { get; set; }

        public string GooglePlusLink { get; set; }

        public string TeamName { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<User> Team
        {
            get
            {
                return this.team;
            }

            set
            {
                this.team = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }

            set
            {
                this.likes = value;
            }
        }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}