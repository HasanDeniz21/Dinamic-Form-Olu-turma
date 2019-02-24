using DynamicForm.Data.Entity.Entity;
using DynamicForm.Data.Repository.Derived;
using DynamicForm.Framework.Data.Repository.EFRepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Repository.Base
{
   public class FormRepository : EntityRepositoryBase<DynamicFormDataContext, Form>, IFormRepository
    {
        public FormRepository(DynamicFormDataContext context) : base(context)
        {

        }
    }
}
