namespace HallOfFame.Data.Contracts
{
    using System.Data.Entity;

    using HallOfFame.Models;

    public interface IHallOfFameDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Like> Likes { get; set; }
    }
}