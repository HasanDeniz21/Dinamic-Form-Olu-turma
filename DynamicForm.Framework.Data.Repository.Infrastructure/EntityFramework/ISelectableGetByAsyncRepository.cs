using DynamicForm.Framework.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace DynamicForm.Framework.Data.Repository.Infrastructure.EntityFramework
{
    public interface ISelectableGetByAsyncRepository<T> : IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetByAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<T> GetSingleByAsync(Expression<Func<T, bool>> filter = null);
    }
}
