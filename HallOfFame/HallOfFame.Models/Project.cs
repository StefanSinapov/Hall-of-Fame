namespace HallOfFame.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        private ICollection<User> contributors;

        private ICollection<Comment> comments;

        private ICollection<Like> likes;

        public Project()
        {
            this.contributors = new HashSet<User>();
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string GitHubLink { get; set; }

        public string FacebookLink { get; set; }

        public string GooglePlusLink { get; set; }

        public virtual ICollection<User> Contributors
        {
            get
            {
                return this.contributors;
            }

            set
            {
                this.contributors = value;
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
    }
}