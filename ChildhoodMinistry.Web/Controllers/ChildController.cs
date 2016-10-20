using ChildhoodMinistry.BL;
using ChildhoodMinistry.Data.Models;
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

        public JsonResult GetPage(int? page, int pageSize)
        {
            var list = service.GetPage(page, pageSize);
            
            Paging<ChildViewModel> result = new Paging<ChildViewModel>()
            {
                currentPage = list.PageNumber,
                pageSize = list.PageSize,
                totalItems = list.TotalItemCount,
                data = new List<ChildViewModel>()
            };

            foreach (var item in list)
            {
                result.data.Add(new ChildViewModel()
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Patronymic = item.Patronymic,
                    Age = item.Age,
                    ChildhoodNum = item.ChildhoodId,
                    Ind = item.Id
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllChildren()
        {
            var result = new List<ChildViewModel>();
            foreach (var item in service.GetItems())
            {
                result.Add(new ChildViewModel()
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Patronymic = item.Patronymic,
                    Age = item.Age,
                    ChildhoodNum = item.ChildhoodId,
                    Ind = item.Id
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildById(int id)
        {
            var item = service.GetItemById(Convert.ToInt32(id));
            var result = new ChildViewModel()
            {
                Name = item.Name,
                Surname = item.Surname,
                Patronymic = item.Patronymic,
                Age = item.Age,
                ChildhoodNum = item.ChildhoodId,
                Ind = item.Id
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChildByChildhoodId(int id)
        {
            var result = new List<ChildViewModel>();
            foreach (var item in service.GetChildByChildhoodId(id))
            {
                result.Add(new ChildViewModel()
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Patronymic = item.Patronymic,
                    Age = item.Age,
                    ChildhoodNum = item.ChildhoodId,
                    Ind = item.Id
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateChild(ChildViewModel child)
        {
            if (child != null && ModelState.IsValid)
            {
                var item = new Child()
                {
                    Name = child.Name,
                    Surname = child.Surname,
                    Patronymic = child.Patronymic,
                    Age = child.Age,
                    ChildhoodId = child.ChildhoodNum,
                    Id = child.Ind
                };
                service.UpdateItem(item);
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
                var item = new Child()
                {
                    Name = child.Name,
                    Surname = child.Surname,
                    Patronymic = child.Patronymic,
                    Age = child.Age,
                    ChildhoodId = child.ChildhoodNum,
                    Id = child.Ind
                };
                service.InsertItem(item);
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
            service.DeleteItem(id);
            return Json("Запись успешно удалена");
        }

    }
}
