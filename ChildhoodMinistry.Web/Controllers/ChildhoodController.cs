using ChildhoodMinistry.BL;
using ChildhoodMinistry.Data.Models;
using PagedList;
using System;
using System.Collections.Generic;
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

        public JsonResult GetPage(int? page, int pageSize)
        {
            var list = service.GetPage(page, pageSize);
            
            Paging<ChildhoodViewModel> result = new Paging<ChildhoodViewModel>()
            {
                currentPage = list.PageNumber,
                pageSize = list.PageSize,
                totalItems = list.TotalItemCount,
                data = new List<ChildhoodViewModel>()
            };

            foreach (var item in list)
            {
                result.data.Add(new ChildhoodViewModel()
                {
                    Ind = item.Id,
                    Number = item.Number,
                    Adress = item.Adress
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllChildhoods()
        {
            var items = new List<ChildhoodViewModel>();
            foreach (var item in service.GetItems())
            {
                items.Add(new ChildhoodViewModel()
                {
                    Ind = item.Id,
                    Number = item.Number,
                    Adress = item.Adress
                });
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildhoodById(int id)
        {
            var item = service.GetItemById(id);
            var result = new ChildhoodViewModel()
            {
                Ind = item.Id,
                Number = item.Number,
                Adress = item.Adress
            };
            return Json(result, JsonRequestBehavior.AllowGet);
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
                var item = new Childhood()
                {
                    Id = childhood.Ind,
                    Number = childhood.Number,
                    Adress = childhood.Adress
                };
                service.UpdateItem(item);
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
                var item = new Childhood()
                {
                    Id = childhood.Ind,
                    Number = childhood.Number,
                    Adress = childhood.Adress
                };
                service.InsertItem(item);
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
            service.DeleteItem(id);
            return Json("Запись успешно удалена");
        }
    }

}
