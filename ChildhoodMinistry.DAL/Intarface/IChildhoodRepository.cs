using ChildhoodMinistry.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.DAL.Intarface
{
    public interface IChildhoodRepository //: IDisposable
    {
        List<Childhood> GetItems();
        void InsertItem(Childhood item);
        void UpdateItem(Childhood item);
        void DeleteItem(int id);
    }
}
 