namespace HallOfFame.Data
{
    using System.Data.Entity;

    using HallOfFame.Common;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Data.Migrations;
    using HallOfFame.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class HallOfFameDbContext : IdentityDbContext<User>, IHallOfFameDbContext
    {
        public HallOfFameDbContext()
            : base(ConnectionStrings.DefaultConnection, throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HallOfFameDbContext, Configuration>());
        }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public static HallOfFameDbContext Create()
        {
            return new HallOfFameDbContext();
        }
      
    }
}