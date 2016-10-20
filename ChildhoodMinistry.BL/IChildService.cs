using ChildhoodMinistry.Data.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.BL
{
    public interface IChildService : ICRUDService<Child>
    {
        List<Child> GetChildByChildhoodId(int id);
        IPagedList<Child> GetPage(int? pageNum, int pageSize);
    }
}
