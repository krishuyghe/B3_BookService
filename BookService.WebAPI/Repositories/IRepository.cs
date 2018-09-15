using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookService.WebAPI.Repositories
{

    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        T Edit(T entity);
    }
}
