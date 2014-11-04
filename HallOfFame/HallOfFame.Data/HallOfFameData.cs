namespace HallOfFame.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Data.Repositories;

    public class HallOfFameData : IHallOfFameData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public HallOfFameData()
            : this(new HallOfFameDbContext())
        {
        }

        public HallOfFameData(DbContext context)
        {
            this.context = context;
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
                var typeOfRepository = typeof(EfRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}