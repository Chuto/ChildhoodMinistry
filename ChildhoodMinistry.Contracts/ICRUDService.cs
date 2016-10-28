using System.Linq;

namespace ChildhoodMinistry.Contracts
{
    public interface ICrudService<T>
    {
        IQueryable<T> GetItems();
        T GetItemById(int id);
        void InsertItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id); 
    }
}
