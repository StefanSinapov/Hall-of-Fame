namespace HallOfFame.Data.Common.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Search(Expression<Func<T, bool>> condition);

        T GetById(int id);

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        void ChangeEntityState(T entity, EntityState state);

        void UpdateValues(Expression<Func<T, object>> entity);

        int SaveChanges();
    }
}
