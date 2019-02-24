using DynamicForm.Data.Entity.Entity;
using DynamicForm.Data.Repository.Derived;
using DynamicForm.Framework.Data.Repository.EFRepositoryBase;
using DynamicForm.Model.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Repository.Base
{
   public class AccountRepository : EntityRepositoryBase<DynamicFormDataContext, Account>, IAccountRepository
    {
        public AccountRepository(DynamicFormDataContext context) : base(context)
        {

        }

        public Account GetUserByEmailAndPasswordForWeb(string email, string password)
        {
            Account loginedUser = _dataContext.Account
                 .FirstOrDefault(x => x.AccountEmail == email && x.AccountPassword == password);

            return loginedUser;
        }
    }
}
