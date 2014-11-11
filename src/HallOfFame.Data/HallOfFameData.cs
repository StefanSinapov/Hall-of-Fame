namespace HallOfFame.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Data.Repositories;
    using HallOfFame.Models;

    public class HallOfFameData : IHallOfFameData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public HallOfFameData(DbContext context)
        {
            this.context = context;
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                return this.GetRepository<Project>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}