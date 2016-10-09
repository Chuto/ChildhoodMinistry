using ChildhoodMinistry.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.DAL.Intarface
{
    public interface IChildRepository //: IDisposable
    {
        List<Child> GetItems();
        void InsertItem(Child item);
        void UpdateItem(Child item);
        void DeleteItem(int id);
    }
}