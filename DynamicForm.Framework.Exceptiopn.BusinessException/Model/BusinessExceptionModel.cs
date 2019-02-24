using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Framework.Exception.Base;

namespace DynamicForm.Framework.Exception.BusinessException.Model
{
    public class BusinessExceptionModel : BaseExceptionModel
    {
        public override string Message { get; set; }
    }
}
