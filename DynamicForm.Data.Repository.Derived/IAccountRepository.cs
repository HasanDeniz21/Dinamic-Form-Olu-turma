using DynamicForm.Data.Entity.Entity;
using DynamicForm.Framework.Data.Repository.Infrastructure;
using DynamicForm.Framework.Data.Repository.Infrastructure.EntityFramework;
using DynamicForm.Model.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Repository.Derived
{
   public interface IAccountRepository : ISelectableRepository<Account>, IUpdatableRepository<Account>, IInsertableRepository<Account>, ISelectableGetByRepository<Account>, IDeleteAbleRepository<Account>
    {
        Account GetUserByEmailAndPasswordForWeb(string email, string password);
    }
}
