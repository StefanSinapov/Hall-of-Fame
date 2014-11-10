namespace HallOfFame.Web.Infrastructure.Identity
{
    using HallOfFame.Models;

    public interface ICurrentUser
    {
        User Get();
    }
}