using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Framework.Exception.Base;
using DynamicForm.Framework.Exception.DataException.Model;

namespace DynamicForm.Framework.Exception.DataException.Model
{
    public class DatabaseExceptionModel : BaseExceptionModel
    {
        public override string Message { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public DbOperationEnum Operation { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public string NameSpace { get; set; }

        public string GetMessage()
        {
            return $"DatabaseName:{this.DatabaseName} TableName:{this.TableName} Operation:{this.Operation} NameSpace:{String.Join(".", this.NameSpace, this.ClassName, this.MethodName)} Message:{this.Message}";
        }

    }
}
