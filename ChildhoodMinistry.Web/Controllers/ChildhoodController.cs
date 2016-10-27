using System;
using System.Linq;
using System.Web.Mvc;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;
using ChildhoodMinistry.Web.Model;
using ChildhoodMinistry.Web.Builders;

namespace ChildhoodMinistry.Web.Controllers
{
    public class ChildhoodController : Controller
    {
        readonly IChildhoodService _service;
        private readonly ICrudService<Childhood> _crudService;
        private readonly IModelBuilder<ChildhoodViewModel, Childhood> _builder;
        readonly PageBuilder<ChildhoodViewModel> _pageBuilder = new PageBuilder<ChildhoodViewModel>();

        public ChildhoodController(IChildhoodService service, ICrudService<Childhood> crudService, IModelBuilder<ChildhoodViewModel, Childhood> builder)
        {
            _service = service;
            _crudService = crudService;
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

        public JsonResult GetChildhoodById(int id)
        {
            var item = _crudService.GetItemById(id);
            return Json(_builder.EntityToModel(item), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNumberOfChildhoods()
        {
            return Json(_service.GetNumberOfChildhoods(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChildhood(ChildhoodViewModel childhood)
        {
            if (childhood != null && ModelState.IsValid)
            {
                _crudService.UpdateItem(_builder.ModelToEntiy(childhood));
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
                _crudService.InsertItem(_builder.ModelToEntiy(childhood));
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
            _crudService.DeleteItem(id);
            return Json("Запись успешно удалена");
        }
    }
}
