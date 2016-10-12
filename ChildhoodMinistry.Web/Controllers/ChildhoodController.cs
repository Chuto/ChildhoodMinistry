using ChildhoodMinistry.BL;
using ChildhoodMinistry.ViewModel;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ChildhoodMinistry.Web.Controllers
{
    public class ChildhoodController : Controller
    {
        IChildhoodService service;

        public ChildhoodController(IChildhoodService s)
        {
            this.service = s;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllChildhoods()
        {
            return Json(service.GetItems(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildhoodById(string id)
        {
            return Json(service.GetItemById(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildhoodNum()
        {
            return Json(service.GetChildhoodNum(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChildhood(ChildhoodViewModel childhood)
        {
            if (childhood != null && ModelState.IsValid)
            {
                service.UpdateItem(childhood);
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
                service.InsertItem(childhood);
                return Json("Данные успешно добавлены");
            }
            else
            {
                return Json(ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage + Environment.NewLine).ToArray());
            }
        }

        [HttpPost]
        public JsonResult DeleteChildhood(string id)
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
