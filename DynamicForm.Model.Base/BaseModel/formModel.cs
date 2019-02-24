using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Model.Base.BaseModel
{
    public class FormModel
    {
        public string FormName { get; set; } 
        public string Description { get; set; }
        public List<FieldModel> fieldModels { get; set; }
    }
}
