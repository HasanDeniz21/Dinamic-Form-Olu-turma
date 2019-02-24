using DynamicForm.Model.Base.BaseModel;
using DynamicForm.WEB.UI.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicForm.WEB.UI.Controllers
{

    [AuthorizeControl(false)]
    public class BaseController : Controller
    {
       
        public AccountModel GetCurrentUser
        {
            get
            {
                AccountModel currentUser = (AccountModel)Session["AccountUser"];
                if (currentUser != null)
                {
                    return currentUser;
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
        }
    }
}