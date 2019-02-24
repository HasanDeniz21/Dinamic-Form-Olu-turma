using DynamicForm.Data.Entity.Entity;
using DynamicForm.Framework.Data.Repository.Infrastructure;
using DynamicForm.Framework.Data.Repository.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Repository.Derived
{
   public interface IFormRepository : ISelectableRepository<Form>, IUpdatableRepository<Form>, IInsertableRepository<Form>, ISelectableGetByRepository<Form>, IDeleteAbleRepository<Form>
    {
    }
}
