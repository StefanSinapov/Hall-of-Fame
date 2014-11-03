namespace HallOfFame.Data
{
    using HallOfFame.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class HallOfFameDbContext : IdentityDbContext<User>
    {
        public HallOfFameDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static HallOfFameDbContext Create()
        {
            return new HallOfFameDbContext();
        }
    }
}