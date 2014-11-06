namespace HallOfFame.Web.Areas.Users.ViewModels
{
    using System;

    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class UserProfileViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AboutMe { get; set; }

        public string AvatarUrl { get; set; }

        public string Website { get; set; }

        public string SkypeName { get; set; }

        public string FacebookProfile { get; set; }

        public string GooglePlusProfile { get; set; }

        public string LinkedInProfile { get; set; }

        public string TwitterProfile { get; set; }

        public string GitHubProfile { get; set; }

        public string TelerikAcademyProfile { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}