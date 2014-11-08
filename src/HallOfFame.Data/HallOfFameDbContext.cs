namespace HallOfFame.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using HallOfFame.Common;
    using HallOfFame.Common.Constants;
    using HallOfFame.Data.Common.Models;
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

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}