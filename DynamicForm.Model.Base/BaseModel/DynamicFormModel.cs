using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Model.Base.BaseModel
{
   public class DynamicFormModel
    {
        public int FormId { get; set; }

        public string FormName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AccountId { get; set; }

        public string Field { get; set; }
    }
}
