using ChildhoodMinistry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.DAL.Intarface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetItems();
        void InsertItem(T item);
        void UpdateItem(T item, object id);
        void DeleteItem(T item);
        void SaveChanges();
    }
}
