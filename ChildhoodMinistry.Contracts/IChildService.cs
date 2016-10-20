using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using ChildhoodMinistry.Data.Models;

namespace ChildhoodMinistry.Contracts
{
    public interface IChildService : ICRUDService<Child>
    {
        List<Child> GetChildByChildhoodId(int id);
        IPagedList<Child> GetPage(int? pageNum, int pageSize);
    }
}
