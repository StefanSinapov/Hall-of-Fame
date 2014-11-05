﻿namespace HallOfFame.Data.Contracts
{
    using System;

    using HallOfFame.Models;

    public interface IHallOfFameData : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Project> Projects { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Course> Courses { get; }

        IRepository<Like> Likes { get; }

        int SaveChanges();
    }
}