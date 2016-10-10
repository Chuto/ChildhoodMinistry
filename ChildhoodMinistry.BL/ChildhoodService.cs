using ChildhoodMinistry.DAL.Intarface;
using ChildhoodMinistry.DAL.Models;
using ChildhoodMinistry.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChildhoodMinistry.BL
{
    public class ChildhoodService : IChildhoodService
    {
        private IRepository<Childhood> childhoods;

        public ChildhoodService(IRepository<Childhood> childhoods)
        {
            this.childhoods = childhoods;
        }

        public List<ChildhoodViewModel> GetItems()
        {
            var result = new List<ChildhoodViewModel>();
            foreach (var obj in childhoods.GetItems())
            {
                result.Add(new ChildhoodViewModel()
                {
                    Ind = obj.Id,
                    Number = obj.Number,
                    Adress = obj.Adress
                });
            }
            return result;
        }

        public ChildhoodViewModel GetItemById(int id)
        {
            var obj = (from item in childhoods.GetItems()
                      where item.Id == id
                      select item).First();
 
            return new ChildhoodViewModel()
            {
                Ind = obj.Id,
                Number = obj.Number,
                Adress = obj.Adress,
            };
        }

        public List<int> GetChildhoodNum()
        {
            return childhoods.GetItems().Select(s => s.Number).ToList();
        }

        public void InsertItem(ChildhoodViewModel item)
        {
            childhoods.InsertItem(new Childhood()
            {
                Id = item.Ind,
                Number = item.Number,
                Adress = item.Adress
            });
        }

        public void UpdateItem(ChildhoodViewModel item)
        {
            childhoods.UpdateItem(new Childhood()
            {
                Id = item.Ind,
                Number = item.Number,
                Adress = item.Adress
            });
        }

        public void DeleteItem(int id)
        {
            childhoods.DeleteItem(id);
        }

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            childhoods.Dispose();
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
