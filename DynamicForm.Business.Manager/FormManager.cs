using DynamicForm.Data.Entity.Entity;
using DynamicForm.Data.UnitOfWork;
using DynamicForm.Framework.Exception.BusinessException;
using DynamicForm.Model.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Manager
{
    public class FormManager
    {
        DynamicFormUnitOfWork _dynamicFormUnitOf;
        public FormManager()
        {
            this._dynamicFormUnitOf = new DynamicFormUnitOfWork();
        }

        public List<DynamicFormModel> GetAllForm()
        {
            try
            {
                List<DynamicFormModel> formModelsList = new List<DynamicFormModel>();
                List<Form> formList = this._dynamicFormUnitOf.FormRepository.GetAll().ToList();
                foreach (var item in formList)
                {
                    formModelsList.Add(new DynamicFormModel()
                    {
                        FormId = item.FormId,
                        AccountId = item.AccountId,
                        CreatedDate = item.CreatedDate,
                        Description = item.Description,
                        Field = item.Field,
                        FormName = item.FormName
                    });
                }
                return formModelsList;
            }
            catch (BusinessException bex)
            {
                throw bex;
            }
        }

        public Form GetFormById(int id)
        {
            try
            {
                return _dynamicFormUnitOf.FormRepository.GetById(id);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }

        public Form CreateForm(Form form)
        {
            try
            {
                return _dynamicFormUnitOf.FormRepository.Insert(form);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }

        public Form UpdateForm(Form form)
        {
            try
            {
                return _dynamicFormUnitOf.FormRepository.Update(form);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }

        public void DeleteFormById(int id)
        {
            try
            {
                _dynamicFormUnitOf.FormRepository.DeleteById(id);
            }
            catch (BusinessException bex)
            {

                throw bex;
            }
        }
    }
}
