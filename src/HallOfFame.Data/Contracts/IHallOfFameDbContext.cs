namespace HallOfFame.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using HallOfFame.Models;

    public interface IHallOfFameDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Conversation> Conversations { get; set; }

        DbContext DbContext { get; }

        void Dispose();

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}