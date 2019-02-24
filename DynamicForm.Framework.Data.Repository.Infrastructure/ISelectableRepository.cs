using DynamicForm.Framework.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DynamicForm.Framework.Data.Repository.Infrastructure
{
    public interface ISelectableRepository<T> : IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> GetTable(int start, int length, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null);
        int GetCount();
    }
}
