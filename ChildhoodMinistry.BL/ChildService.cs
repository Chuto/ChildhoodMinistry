using ChildhoodMinistry.DAL.Intarface;
using ChildhoodMinistry.DAL.Models;
using ChildhoodMinistry.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ChildhoodMinistry.BL
{
    public class ChildService : IChildService
    {
        private IRepository<Child> children;

        public ChildService(IRepository<Child> children)
        {
            this.children = children;
        }

        public List<ChildViewModel> GetItems()
        {
            var result = new List<ChildViewModel>();
            foreach (var obj in children.GetItems())
            {
                result.Add(new ChildViewModel() {
                    Ind = obj.Id,
                    Name = obj.Name,
                    Surname = obj.Surname,
                    Patronymic = obj.Patronymic,
                    Age = obj.Age,
                    ChildhoodNum = obj.ChildhoodId                    
                });
            }         
            return result;
        }

        public ChildViewModel GetItemById(int id)
        {
            var obj = (from item in children.GetItems()
                       where item.Id == id
                       select item).First();

            return new ChildViewModel()
            {
                Ind = obj.Id,
                Name = obj.Name,
                Surname = obj.Surname,
                Patronymic = obj.Patronymic,
                Age = obj.Age,
                ChildhoodNum = obj.ChildhoodId
            };
        }

        public List<ChildViewModel> GetChildByChildhoodId(int id)
        {
            var result = new List<ChildViewModel>();
            foreach (var obj in children.GetItems().Where(s => s.ChildhoodId == id))
            {
                result.Add(new ChildViewModel()
                {
                    Ind = obj.Id,
                    Name = obj.Name,
                    Surname = obj.Surname,
                    Patronymic = obj.Patronymic,
                    Age = obj.Age,
                    ChildhoodNum = obj.ChildhoodId
                });
            }
            return result;
        }

        public void InsertItem(ChildViewModel item)
        {
            children.InsertItem(new Child() {
                Id = item.Ind,
                Name = item.Name,
                Surname = item.Surname,
                Patronymic = item.Patronymic,
                Age = item.Age,
                ChildhoodId = item.ChildhoodNum
            });
        }

        public void UpdateItem(ChildViewModel item)
        {
            children.UpdateItem(new Child()
            {
                Id = item.Ind,
                Name = item.Name,
                Surname = item.Surname,
                Patronymic = item.Patronymic,
                Age = item.Age,
                ChildhoodId = item.ChildhoodNum
            });
        }

        public void DeleteItem(int id)
        {
            children.DeleteItem(id);
        }

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            children.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
