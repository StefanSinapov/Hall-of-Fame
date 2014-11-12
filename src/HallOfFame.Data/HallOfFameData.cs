namespace HallOfFame.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using HallOfFame.Data.Common.Models;
    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Data.Repositories;
    using HallOfFame.Models;

    public class HallOfFameData : IHallOfFameData
    {
        private readonly IHallOfFameDbContext context;

        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public HallOfFameData(IHallOfFameDbContext context)
        {
            this.context = context;
        }

        public IHallOfFameDbContext Context
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
                return this.GetDeletableEntityRepository<Project>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetDeletableEntityRepository<Category>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetDeletableEntityRepository<Comment>();
            }
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.GetDeletableEntityRepository<Course>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetDeletableEntityRepository<Like>();
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

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}