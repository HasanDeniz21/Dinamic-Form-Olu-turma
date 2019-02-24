using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Model.Base.BaseModel
{
   public class FieldModel
    {
        public bool required { get; set; }
        public string dataType { get; set; }
        public string name { get; set; }
    }
}
