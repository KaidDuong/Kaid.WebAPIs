using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Kaid.WebAPI.Data.Infrastructure
{
    public abstract class RespositoryBase<T> :IRespository<T> where T : class
    {
        #region Properties

        private KaidDbContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get; private set;
        }

        protected KaidDbContext DbContext
        {
            get
            {
                return dataContext ??
                    (dataContext = DbFactory.Init());
            }
        }

        #endregion Properties

        protected RespositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetSingleByCondition(
            Expression<Func<T, bool>> expression, string[] includes = null)
        {
            return GetAll(includes).FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetMany(
            Expression<Func<T, bool>> where, string includes)
        {
            return dbSet.Where(where).ToList();
        }

        public IQueryable<T> GetAll(string[] includes = null)
        {
            //handle includes for associated objects if applicable
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.AsQueryable();
            }
            return dataContext.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> GetMulti(
            Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //handle includes for associated objects if applicable
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.Where<T>(predicate).AsQueryable<T>();
            }
            return dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> GetMultiPaging(
            Expression<Func<T, bool>> predicate, out int total,
            int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            //handle includes for associated objects if applicable
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                _resetSet = (predicate != null) ?
                    query.Where<T>(predicate).AsQueryable<T>()
                    : query.AsQueryable<T>();
            }
            else
            {
                _resetSet = predicate != null ?
                    dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>()
                    : dataContext.Set<T>().AsQueryable<T>();
            }
            _resetSet = skipCount == 0 ? _resetSet.Take(size)
                                       : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().Count<T>(predicate) > 0;
        }

        #endregion Implementation
    }
}