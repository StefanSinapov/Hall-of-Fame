namespace HallOfFame.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using HallOfFame.Common.Constants;
    using HallOfFame.Data.Common.CodeFirstConventions;
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
      
        public virtual IDbSet<Project> Projects { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
        
        public virtual IDbSet<Comment> Comments { get; set; }
        
        public virtual IDbSet<Course> Courses { get; set; }
        
        public virtual IDbSet<Like> Likes { get; set; }
        
        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Conversation> Conversations { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model
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