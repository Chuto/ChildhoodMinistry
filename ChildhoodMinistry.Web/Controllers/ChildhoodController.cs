using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;
using ChildhoodMinistry.Web.Model;
using ChildhoodMinistry.Web.Builders;
using ChildhoodMinistry.Web.Interface;

namespace ChildhoodMinistry.Web.Controllers
{
    public class ChildhoodController : Controller
    {
        readonly IChildhoodService _service;
        private readonly IModelBuilder<ChildhoodViewModel, Childhood> _builder;
        readonly PageBuilder<ChildhoodViewModel> _pageBuilder = new PageBuilder<ChildhoodViewModel>();

        public ChildhoodController(IChildhoodService service, IModelBuilder<ChildhoodViewModel, Childhood> builder)
        {
            _service = service;
            _builder = builder;
        }

        public ActionResult Index()
        { 
            return View();
        }

        public JsonResult GetPage(int? page, int pageSize)
        {
            var list = _service.GetPage(page, pageSize);
            var result = _pageBuilder.BuildPage(list, list.Select(item => _builder.EntityToModel(item)).ToList());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildhoodById(int id)
        {
            var result = _builder.EntityToModel(_service.GetItemById(id));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildhoods()
        {
            var result = new List<ChildhoodViewModel>();
            foreach (var item in _service.GetItems())
                result.Add(_builder.EntityToModel(item));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChildhood(ChildhoodViewModel childhood)
        {
            if (childhood != null && ModelState.IsValid)
            {
                _service.UpdateItem(_builder.ModelToEntiy(childhood));
                return Json("Изменения успешно сохранены");
            }
            else
            {
                return Json(ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage + Environment.NewLine).ToArray());
            }
        }

        [HttpPost]
        public JsonResult AddChildhood(ChildhoodViewModel childhood)
        {
            if (childhood != null && ModelState.IsValid)
            {
                _service.InsertItem(_builder.ModelToEntiy(childhood));
                return Json("Данные успешно добавлены");
            }
            else
            {
                return Json(ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage + Environment.NewLine).ToArray());
            }
        }

        [HttpPost]
        public JsonResult DeleteChildhood(int id)
        {
            _service.DeleteItem(id);
            return Json("Запись успешно удалена");
        }
    }
}
