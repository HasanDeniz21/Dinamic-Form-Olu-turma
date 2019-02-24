using DynamicForm.Business.Manager;
using DynamicForm.Data.Entity.Entity;
using DynamicForm.Model.Base.BaseModel;
using DynamicForm.WEB.UI.filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicForm.WEB.UI.Controllers
{

    [AuthorizeControl(true)]
    public class FormController : BaseController
    {
        FormManager _formManager;
        public FormController()
        {
            _formManager = new FormManager();
        }
        public ActionResult Index()
        {
            return View(_formManager.GetAllForm());
        }
        [Route("forms/{ID}")]
        public ActionResult GetForm(int ID)

        {
            Form form = _formManager.GetFormById(ID);
            List<FieldModel> modelFields = JsonConvert.DeserializeObject<List<FieldModel>>(form.Field);
            FormModel formModel = new FormModel()
            {
                FormName = form.FormName,
                Description = form.Description,
                fieldModels = modelFields
            };
            return View(formModel);
        }
        [HttpPost]
        public ActionResult Create(List<string> listData)
        {
            List<FieldModel> fieldModelList = new List<FieldModel>();
            for (int i = 2; i < listData.Count;)
            {
                fieldModelList.Add(new FieldModel()
                {
                    required = Convert.ToBoolean(listData[i++].Split('#')[1]),
                    dataType = listData[i++].Split('#')[1],
                    name = listData[i++].Split('#')[1]
                });
            }
            string json = JsonConvert.SerializeObject(fieldModelList);
            DynamicFormModel formModel = new DynamicFormModel();
            formModel.FormName = listData[0].Split('#')[1];
            formModel.Description = listData[1].Split('#')[1];
            formModel.CreatedDate = DateTime.Now;
            formModel.AccountId = GetCurrentUser.AccountId;
            formModel.Field = json;

            Form form = new Form()
            {
                FormName = formModel.FormName,
                Description = formModel.Description,
                CreatedDate = formModel.CreatedDate,
                Field = formModel.Field,
                AccountId = formModel.AccountId
            };

            _formManager.CreateForm(form);

            return RedirectToAction("Index");
        }
        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            _formManager.DeleteFormById(id);
            return RedirectToAction("Index");
        }
    }
}