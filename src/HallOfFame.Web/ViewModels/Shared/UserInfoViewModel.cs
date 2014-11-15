namespace HallOfFame.Web.ViewModels.Shared
{
    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class UserInfoViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }
    }
}