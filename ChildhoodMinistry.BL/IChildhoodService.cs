using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using ChildhoodMinistry.Data.Models;

namespace ChildhoodMinistry.BL
{
    public interface IChildhoodService : ICRUDService<Childhood>
    {
        List<int> GetChildhoodNum();
        IPagedList<Childhood> GetPage(int? pageNum, int pageSize);
    }
}
