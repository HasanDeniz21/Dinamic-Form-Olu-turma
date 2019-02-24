using DynamicForm.Framework.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DynamicForm.Framework.Data.Repository.Infrastructure
{
    public interface IInsertableRepository<T> : IRepository<T> where T : class, IEntity
    {
        T Insert(T item);
    }
}
