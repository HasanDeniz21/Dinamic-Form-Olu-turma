using DynamicForm.Framework.Data.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DynamicForm.Framework.Data.Repository.Infrastructure
{
    public interface ISelectableAsyncRepository<T> : IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
    }
}
