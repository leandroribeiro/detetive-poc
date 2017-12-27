using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Detetive.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetByID(object id);

        TEntity GetRandom();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        int Count();
    }

}
