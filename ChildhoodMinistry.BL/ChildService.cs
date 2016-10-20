using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Models;

namespace ChildhoodMinistry.BL
{
    public class ChildService : IChildService
    {
        private IRepository<Child> children;

        public ChildService(IRepository<Child> children)
        {
            this.children = children;
        }

        public List<Child> GetItems()
        {
            var result = new List<Child>();
            foreach (var obj in children.GetItems())
            {
                result.Add(obj);
            }         
            return result;
        }

        public Child GetItemById(int id)
        {
            return (from item in children.GetItems()
                    where item.Id == id
                    select item).First();
        }

        public List<Child> GetChildByChildhoodId(int id)
        {
            var result = new List<Child>();
            foreach (var obj in children.GetItems().Where(s => s.ChildhoodId == id))
            {
                result.Add(obj);
            }
            return result;
        }

        public void InsertItem(Child item)
        {
            children.InsertItem(item);
            children.SaveChanges();
        }

        public void UpdateItem(Child item)
        {
            children.UpdateItem(item, item.Id);
            children.SaveChanges();
        }
        
        public void DeleteItem(int id)
        {
            var obj = (from item in children.GetItems()
                       where item.Id == id
                       select item).First();
            children.DeleteItem(obj);
            children.SaveChanges();
        }

        public IPagedList<Child> GetPage(int? pageNum, int pageSize)
        {
            return children.GetItems().OrderBy(x => x.Surname).ToPagedList<Child>((pageNum ?? 1), pageSize);
        }
    }
}
