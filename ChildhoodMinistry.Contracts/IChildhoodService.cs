using System.Collections.Generic;
using ChildhoodMinistry.Data.Model;
using PagedList;

namespace ChildhoodMinistry.Contracts
{
    public interface IChildhoodService : ICrudService<Childhood>
    {
        IPagedList<Childhood> GetPage(int? pageNum, int pageSize);
    }
}
