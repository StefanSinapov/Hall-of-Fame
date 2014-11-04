namespace HallOfFame.Data
{
    using System.Data.Entity;

    using HallOfFame.Common;
    using HallOfFame.Data.Migrations;
    using HallOfFame.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class HallOfFameDbContext : IdentityDbContext<User>
    {
        public HallOfFameDbContext()
            : base(ConnectionStrings.DefaultConnection, throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HallOfFameDbContext, Configuration>());
        }

        public static HallOfFameDbContext Create()
        {
            return new HallOfFameDbContext();
        }
    }
}