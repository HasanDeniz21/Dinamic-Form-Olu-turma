using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Model.Base.BaseModel
{
   public class AccountModel
    {
        public int AccountId { get; set; }

        
        public string AccountName { get; set; }
        
        public string AccountSurname { get; set; }

        public int AccountAge { get; set; }

        public string AccountEmail { get; set; }

        public string AccountPassword { get; set; }
    }
}
