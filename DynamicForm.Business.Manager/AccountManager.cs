using DynamicForm.Data.Entity.Entity;
using DynamicForm.Data.Repository.Base;
using DynamicForm.Data.UnitOfWork;
using DynamicForm.Framework.Exception.BusinessException;
using DynamicForm.Framework.Exception.BusinessException.Model;
using DynamicForm.Model.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Manager
{
    public class AccountManager
    {

        DynamicFormUnitOfWork _dynamicFormUnitOf;
        public AccountManager()
        {
            this._dynamicFormUnitOf = new DynamicFormUnitOfWork();
        }

        public List<Account> GetAllAccount()
        {
            try
            {
                return this._dynamicFormUnitOf.AccountRepository.GetAll().ToList();
            }
            catch (BusinessException bex)
            {
                throw bex;
            }
        }

        public Account GetAccountById(int id)
        {
            try
            {
                return _dynamicFormUnitOf.AccountRepository.GetById(id);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }

        public Account CreateAccount(Account account)
        {
            try
            {
                return _dynamicFormUnitOf.AccountRepository.Insert(account);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }

        public Account UpdateAccount(Account account)
        {
            try
            {
                return _dynamicFormUnitOf.AccountRepository.Update(account);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }

        public void DeleteAccountById(int id)
        {
            try
            {
                _dynamicFormUnitOf.AccountRepository.DeleteById(id);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }

        public AccountModel AccountLogin(LoginWebModel model)
        {
            var userLogin = _dynamicFormUnitOf.AccountRepository.GetUserByEmailAndPasswordForWeb(model.AccountEmail, model.AccountPassword);

            if (userLogin == null)
            {
                throw new BusinessException(new BusinessExceptionModel(), "E-Mail Veya Şifre Bulunamadı");
            }
            AccountModel account = new AccountModel
            {
                AccountId=userLogin.AccountId,
                AccountAge=userLogin.AccountAge,
                AccountName =userLogin.AccountName,
                AccountEmail = userLogin.AccountEmail,
                AccountSurname =userLogin.AccountSurname,
                AccountPassword=userLogin.AccountPassword,
              
            };

            return account;

        }



    }
}
