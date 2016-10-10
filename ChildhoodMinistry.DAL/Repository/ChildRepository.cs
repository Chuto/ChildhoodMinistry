using System.Collections.Generic;
using System.Linq;
using ChildhoodMinistry.DAL.Intarface;
using System.Data.Entity;
using ChildhoodMinistry.DAL.Models;
using System;

namespace ChildhoodMinistry.DAL
{
    public class ChildRepository : IRepository<Child>//IChildRepository
    {
        public List<Child> GetItems()
        {
            var result = new List<Child>();
            using (var db = new ContextDB())
            {
                result = (from items in db.children_data
                          select items).ToList();
            }
            return result;
        }

        public void InsertItem(Child item)
        {
            using (var db = new ContextDB())
            {
                db.children_data.Add(item);
                db.save();
            }
        }

        public void UpdateItem(Child item)
        {
            using (var db = new ContextDB())
            {
                var obj = db.children_data.Find(item.Id);
                obj.Name = item.Name;
                obj.Surname = item.Surname;
                obj.Patronymic = item.Patronymic;
                obj.Age = item.Age;
                obj.ChildhoodId = item.ChildhoodId;
                db.save();
            }
        }

        public void DeleteItem(int id)
        {
            using (var db = new ContextDB())
            {
                Child item = db.children_data.Find(id);
                db.children_data.Remove(item);
                db.save();
            }
        }

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {  
        //            _context.Dispose();
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
