using ChildhoodMinistry.BL;
using ChildhoodMinistry.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ChildhoodMinistry.Web.Controllers
{
    public class ChildController : Controller
    {
        IChildService service;

        public ChildController(IChildService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllChildren()
        {
            return Json(service.GetItems(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildById(string id)
        {
            return Json(service.GetItemById(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildByChildhoodId(string id)
        {
            return Json(service.GetChildByChildhoodId(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChild(ChildViewModel child)
        {
            if (child != null && ModelState.IsValid)
            {
                service.UpdateItem(child);
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
                service.InsertItem(child);
                return Json("Данные успешно добавлены");
            }
            else
            {
                return Json(ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage+Environment.NewLine).ToArray());
            }
        }

        [HttpPost]
        public JsonResult DeleteChild(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                service.DeleteItem(Convert.ToInt32(id));
                return Json("Запись успешно удалена");
            }
            else
            {
                return Json("Не удалось удалить запись");
            }
        }

    }
}
