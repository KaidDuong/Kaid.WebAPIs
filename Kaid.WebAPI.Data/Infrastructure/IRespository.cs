﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kaid.WebAPI.Data.Infrastructure
{
    public interface IRespository<T> where T : class
    {
        //Marks an entity as new
        void Add(T entity);

        //Marks an entity as modifided or save as
        void Update(T entity);

        //Marks an entity to be removed
        void Delete(T entity);
        void Delete(int entity);

        //Delete multi-records
        void DeleteMulti(Expression<Func<T, bool>> where);

        //Get an entity by ID
        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T,
            bool>> expression, string[] includes = null);

        IQueryable<T> GetAll(string[] includes = null);

        IQueryable<T> GetMulti(Expression<Func<T,
            bool>> predicate, string[] includes = null);

        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filler,
            out int total, int index = 0, int size = 50,
            string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}