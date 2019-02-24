using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Framework.Exception.Base;
using DynamicForm.Framework.Exception.BusinessException.Model;

namespace DynamicForm.Framework.Exception.BusinessException
{
    public class BusinessException : BaseException
    {
        private List<BusinessExceptionModel> businessException;

        protected void Initialize()
        {
            this.businessException = new List<BusinessExceptionModel>();
        }

        public BusinessException(BusinessExceptionModel model, string message) : base(model.Message)
        {
            Initialize();
            businessException.Add(model);
        }
        public BusinessException(IList<BusinessExceptionModel> model, string message) : base(String.Join("-|-", model, message))
        {
            Initialize();
            businessException.AddRange(model);
        }

        public BusinessException(BusinessExceptionModel model, string message, System.Exception innerException) : base(String.Join("-|-", model.Message, message), innerException)
        {
            Initialize();
            businessException.Add(model);
        }
    }
}
