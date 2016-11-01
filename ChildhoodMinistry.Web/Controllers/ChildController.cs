using System;
using System.Linq;
using System.Web.Mvc;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;
using ChildhoodMinistry.Web.Builders;
using ChildhoodMinistry.Web.Interface;
using ChildhoodMinistry.Web.Model;

namespace ChildhoodMinistry.Web.Controllers
{
    public class ChildController : Controller
    {
        readonly IChildService _service;
        private readonly IModelBuilder<ChildViewModel, Child> _builder;
        readonly PageBuilder<ChildViewModel> _pageBuilder = new PageBuilder<ChildViewModel>(); 

        public ChildController(IChildService service, IModelBuilder<ChildViewModel, Child> builder)
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
            var result = _pageBuilder.BuildPage(list,list.Select(item => _builder.EntityToModel(item)).ToList());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildById(int id)
        {
            var result = _builder.EntityToModel(_service.GetItemById(id));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildByChildhoodNum(int id)
        {
            var children = _service.GetChildrenByChildhoodId(id);
            var result = children.Select(item => _builder.EntityToModel(item)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChild(ChildViewModel child)
        {
            if (child != null && ModelState.IsValid)
            {
                var item = _builder.ModelToEntiy(child);
                _service.UpdateItem(item);
                return Json("Изменения успешно сохранены");
            }
            else
            {
                return Json(ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage+ Environment.NewLine).ToArray() );
            }
        }

        [HttpPost]
        public JsonResult AddChild(ChildViewModel child)
        {
            if (child != null && ModelState.IsValid)
            {
                var item = _builder.ModelToEntiy(child);
                _service.InsertItem(item);
                return Json("Данные успешно добавлены");
            }
            else
            {
                return Json(ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage+Environment.NewLine).ToArray());
            }
        }

        [HttpPost]
        public JsonResult DeleteChild(int id)
        {
            _service.DeleteItem(id);
            return Json("Запись успешно удалена");
        }
    }
}
