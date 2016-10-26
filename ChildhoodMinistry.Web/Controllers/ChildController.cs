using System;
using System.Linq;
using System.Web.Mvc;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;
using ChildhoodMinistry.Web.Builders;
using ChildhoodMinistry.Web.Model;

namespace ChildhoodMinistry.Web.Controllers
{
    public class ChildController : Controller
    {
        readonly IChildService _service;
        private readonly ICrudService<Child> _crudService;
        private readonly IModelBuilder<ChildViewModel, Child> _builder;
        readonly PageBuilder<ChildViewModel> _pageBuilder = new PageBuilder<ChildViewModel>(); 

        public ChildController(IChildService service, ICrudService<Child> crudService, IModelBuilder<ChildViewModel, Child> builder)
        {
            _crudService = crudService;
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
            return Json(_pageBuilder.BuildPage(list, list.Select(item => _builder.EntityToModel(item)).ToList()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildById(int id)
        {
            var item = _crudService.GetItemById(id);
            return Json(_builder.EntityToModel(item), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildByChildhoodId(int id)
        {
            var result = _service.GetChildByChildhoodId(id).Select(item => _builder.EntityToModel(item)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChild(ChildViewModel child)
        {
            if (child != null && ModelState.IsValid)
            {
                _crudService.UpdateItem(_builder.ModelToEntiy(child));
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
                _crudService.InsertItem(_builder.ModelToEntiy(child));
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
            _crudService.DeleteItem(id);
            return Json("Запись успешно удалена");
        }
    }
}
