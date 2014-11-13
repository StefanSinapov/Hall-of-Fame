namespace HallOfFame.Data.Contracts
{
    using System;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;

    public interface IHallOfFameData : IDisposable
    {
        IHallOfFameDbContext Context { get; }

        IRepository<User> Users { get; }

        IRepository<Project> Projects { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Course> Courses { get; }

        IRepository<Like> Likes { get; }
        
        IRepository<Message> Messages { get; }

        IRepository<Conversation> Conversations { get; }

        int SaveChanges();
    }
}