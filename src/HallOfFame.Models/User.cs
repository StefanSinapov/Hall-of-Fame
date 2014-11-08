namespace HallOfFame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;    
    using System.Security.Claims;
    using System.Threading.Tasks;

    using HallOfFame.Common.Constants;
    using HallOfFame.Data.Common.Models;
    using HallOfFame.Models.Enums;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Project> projects;

        private ICollection<Comment> comments;

        private ICollection<Like> likes;

        public User()
        {
            this.AvatarUrl = GlobalConstants.DefaultAvatarUrl;
            this.DateRegistered = DateTime.Now;
            this.projects = new HashSet<Project>();
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string AboutMe { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public string AvatarUrl { get; set; }

        public string Website { get; set; }

        public string SkypeName { get; set; }

        public string FacebookProfile { get; set; }

        public string GooglePlusProfile { get; set; }

        public string LinkedInProfile { get; set; }

        public string TwitterProfile { get; set; }

        public string GitHubProfile { get; set; }

        public string TelerikAcademyProfile { get; set; }

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

        #region IAuditInfo

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        #endregion

        #region IDeletableEntity

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}