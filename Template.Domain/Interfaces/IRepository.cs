using System;
using System.Linq;
using System.Linq.Expressions;

namespace Template.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);

        TEntity Create(TEntity entity);

        TEntity Find(Expression<Func<TEntity, bool>> where);

        public bool Delete(TEntity model);
    }
}
