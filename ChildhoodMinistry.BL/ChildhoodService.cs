using ChildhoodMinistry.DAL.Intarface;
using ChildhoodMinistry.Data.Models;
using PagedList;
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

        public List<Childhood> GetItems()
        {
            var result = new List<Childhood>();
            foreach (Childhood obj in childhoods.GetItems())
            {
                result.Add(obj);
            }
            return result;
        }

        public Childhood GetItemById(int id)
        {
            return (from item in childhoods.GetItems()
                    where item.Id == id
                    select item).First();
        }

        public List<int> GetChildhoodNum()
        {
            return (from nums in childhoods.GetItems()
                    select nums.Number).ToList();
        }

        public void InsertItem(Childhood item)
        {
            childhoods.InsertItem(item);
            childhoods.SaveChanges();
        }

        public void UpdateItem(Childhood item)
        {
            childhoods.UpdateItem(item, item.Id);
            childhoods.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var obj = (from item in childhoods.GetItems()
                       where item.Id == id
                       select item).First();
            childhoods.DeleteItem(obj);
            childhoods.SaveChanges();
        }

        public IPagedList<Childhood> GetPage(int? pageNum, int pageSize)
        {
            return childhoods.GetItems().OrderBy(x => x.Number).ToPagedList<Childhood>((pageNum ?? 1), pageSize);
        }
    }
}
