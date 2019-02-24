using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Framework.Exception.Base
{
    public abstract class BaseException : System.Exception
    {
        public List<string> Messages { get; private set; }

        protected void Initialize()
        {
            this.Messages = new List<string>();
        }
        protected BaseException(string message) : base(message)
        {
            Initialize();
            this.Messages.Add(message);
        }

        protected BaseException(string message, System.Exception innerException) : base(message, innerException)
        {
            Initialize();
            this.Messages.Add(String.Join("-|-", message, innerException));
        }
    }
}
