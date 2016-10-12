using System.Collections.Generic;
using System.Linq;
using ChildhoodMinistry.DAL.Intarface;
using System.Data.Entity;
using ChildhoodMinistry.DAL.Models;
using System;

namespace ChildhoodMinistry.DAL
{
    public class ChildhoodRepository : IRepository<Childhood>
    {

        public List<Childhood> GetItems()
        {
            var result = new List<Childhood>();
            using (var db = new ContextDB())
            {
                var result1 = db.childhoods_data.ToList();
                ;
            }
            using (var db = new ContextDB())
            {
                result = (from items in db.childhoods_data
                        select items).ToList();
            }

            return result;
        }

        public void InsertItem(Childhood item)
        {
            using (var db = new ContextDB())
            {
                db.childhoods_data.Add(item);
                db.save();
            }
        }

        public void UpdateItem(Childhood item)
        {
            using (var db = new ContextDB())
            {
                var obj = db.childhoods_data.Find(item.Id);
                obj.Adress = item.Adress;
                obj.Number = item.Number;
                db.save();
            }
        }

        public void DeleteItem(int id)
        {
            using (var db = new ContextDB())
            {
                Childhood item = db.childhoods_data.Find(id);
                db.childhoods_data.Remove(item);
                db.save();
            }
        }
    }
}
