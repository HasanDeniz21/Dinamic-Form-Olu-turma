using DynamicForm.Business.Manager;
using DynamicForm.Data.Entity.Entity;
using DynamicForm.Framework.Exception.BusinessException;
using DynamicForm.Model.Base.BaseModel;
using DynamicForm.WEB.UI.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicForm.WEB.UI.Controllers
{
  
    public class AccountController : BaseController
    {
        AccountManager _accountManager;
        public AccountController()
        {
            _accountManager = new AccountManager();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountModel accountModel)
        {
            try
            {
                if (accountModel != null)
                {
                    Account account = new Account()
                    {
                        AccountName = accountModel.AccountName,
                        AccountSurname = accountModel.AccountSurname,
                        AccountAge = accountModel.AccountAge,
                        AccountEmail = accountModel.AccountEmail,
                        AccountPassword = accountModel.AccountPassword
                    };
                    _accountManager.CreateAccount(account);

                    return RedirectToAction("Login", "Account");
                }
             
            }
            catch (BusinessException bex)
            {
                ViewBag.ErrorMessage = bex.InnerException;
            }
            return null;
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeControl(false)]
        public ActionResult Login(LoginWebModel loginWeb)
        {
            try
            {
                var result = _accountManager.AccountLogin(loginWeb);

                if (result!=null)
                {
                    Session["AccountUser"] = result;
                }

                Session["AccountUser"] = result;
                Session["AccountName"] = result.AccountName + " " + result.AccountSurname;
                Session["AccountId"] = result.AccountId;

                return RedirectToAction("Index", "Home");
            }
            catch (BusinessException bex)
            {
                ViewBag.ErrorMessage = bex.InnerException;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}