using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int pageIndex, int pageSize);
        IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
