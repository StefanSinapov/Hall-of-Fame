namespace HallOfFame.Web.ViewModels.Shared
{
    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class UserInfoViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string AvatarUrl { get; set; }
    }
}