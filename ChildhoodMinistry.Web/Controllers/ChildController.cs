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
        readonly IChildhoodService _childhood;
        private readonly IModelBuilder<ChildViewModel, Child> _builder;
        readonly PageBuilder<ChildViewModel> _pageBuilder = new PageBuilder<ChildViewModel>(); 

        public ChildController(IChildService service, IChildhoodService childhood, IModelBuilder<ChildViewModel, Child> builder)
        {
            _service = service;
            _childhood = childhood;
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
            var item = _service.GetItemById(id);
            return Json(_builder.EntityToModel(item), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildByChildhoodNum(int num)
        {
            var result = _childhood.GetItems().First(s => s.Number == num).Children.Select(item => _builder.EntityToModel(item)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChild(ChildViewModel child)
        {
            if (child != null && ModelState.IsValid)
            {
                var item = _builder.ModelToEntiy(child);
                item.ChildhoodId = _childhood.GetItems().First(s => s.Number == child.ChildhoodNum).Id;
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
                item.ChildhoodId = _childhood.GetItems().First(s => s.Number == child.ChildhoodNum).Id;
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
