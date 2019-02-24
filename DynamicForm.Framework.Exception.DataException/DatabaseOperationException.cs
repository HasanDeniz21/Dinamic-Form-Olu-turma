using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Framework.Exception.Base;
using DynamicForm.Framework.Exception.DataException.Model;

namespace DynamicForm.Framework.Exception.DataException
{
    public class DatabaseOperationException : BaseException
    {
        public DatabaseExceptionModel DatabaseException { get; }

        public DatabaseOperationException(DatabaseExceptionModel model, string message) : base(String.Join("-|-", model.GetMessage(), message))
        {
            DatabaseException = model;
        }

        public DatabaseOperationException(DatabaseExceptionModel model, string message, System.Exception innerException) : base(String.Join("-|-", model.GetMessage(), message), innerException)
        {
            DatabaseException = model;
        }
    }
}
