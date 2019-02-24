using DynamicForm.Framework.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DynamicForm.Framework.Data.Repository.Infrastructure.EntityFramework
{
    public interface ISelectableGetByRepository<T> : IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetBy(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T GetSingleBy(Expression<Func<T, bool>> filter = null);
    }
}
