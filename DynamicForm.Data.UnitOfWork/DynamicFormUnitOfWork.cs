using DynamicForm.Data.Entity.Entity;
using DynamicForm.Data.Repository.Base;
using DynamicForm.Data.Repository.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.UnitOfWork
{
    public class DynamicFormUnitOfWork
    {
        DynamicFormDataContext _dataContext;
        IAccountRepository _accountRepository;
        IFormRepository _formRepository;


        public DynamicFormUnitOfWork()
        {
            _dataContext = new DynamicFormDataContext();
        }

        public IAccountRepository AccountRepository =>_accountRepository ?? (_accountRepository = new AccountRepository(_dataContext));
        public IFormRepository FormRepository => _formRepository ?? (_formRepository = new FormRepository(_dataContext));
    }
}
