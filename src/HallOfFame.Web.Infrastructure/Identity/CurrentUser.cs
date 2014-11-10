namespace HallOfFame.Web.Infrastructure.Identity
{
    using System.Security.Principal;
    using System.Web;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Models;

    using Microsoft.AspNet.Identity;

    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity currentIdentity;
        private readonly IHallOfFameDbContext currentDbContext;

        private User user;

        public CurrentUser(IHallOfFameDbContext context)
        {
            this.currentIdentity = HttpContext.Current.User.Identity;
            this.currentDbContext = context;
        }

        public User Get()
        {
            return this.user ?? (this.user = this.currentDbContext.Users.Find(this.currentIdentity.GetUserId()));
        }
    }
}