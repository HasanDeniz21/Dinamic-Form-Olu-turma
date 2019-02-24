using DynamicForm.Model.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicForm.WEB.UI.filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AuthorizeControlAttribute : AuthorizeAttribute
    {
        private bool _authorize;
        public AuthorizeControlAttribute()
        {
            _authorize = true;
        }
        public AuthorizeControlAttribute(bool authorize)
        {
            _authorize = authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            AccountModel currentUser = (AccountModel)HttpContext.Current.Session["AccountUser"];
            HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            if (currentUser == null)
            {
                filterContext.HttpContext.Response.Redirect("/Account/Login", true);
                filterContext.Result = new HttpUnauthorizedResult();
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/Account/AccessDenied", true);
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (!this._authorize)
                return true;

            AccountModel currentUser = (AccountModel)HttpContext.Current.Session["AccountUser"];
            if (currentUser == null)
                return false;

            return true;
        }
    }
}