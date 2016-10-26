using System.Linq;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetItems();
        T GetItemById(int id);
        void InsertItem(T item);
        void UpdateItem(T item, object id);
        void DeleteItem(int id);
        void SaveChanges();
    }
}
