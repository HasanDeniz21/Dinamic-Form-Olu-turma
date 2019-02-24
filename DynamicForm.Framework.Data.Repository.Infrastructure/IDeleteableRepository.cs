using DynamicForm.Framework.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DynamicForm.Framework.Data.Repository.Infrastructure
{
    public interface IDeleteAbleRepository<T> : IRepository<T> where T : class, IEntity
    {
        void Delete(T item);
        void DeleteById(object id);
    }
}
