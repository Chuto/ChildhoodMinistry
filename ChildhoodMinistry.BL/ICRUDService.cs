using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.BL
{
    public interface ICRUDService<T>
    {
        List<T> GetItems();
        T GetItemById(int id);
        void InsertItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id); 
    }
}
