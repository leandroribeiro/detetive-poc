using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Detetive.Domain.Repositories;

namespace Detetive.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context = null;
        private readonly DbSet<T> _dbSet;

        protected Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public T GetRandom()
        {
            return _dbSet.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            ((IObjectContextAdapter) _context).ObjectContext.ObjectStateManager.ChangeObjectState(entity,
                EntityState.Modified);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public int Count()
        {
            return _dbSet.Count();
        }
    }
}
