using System.Collections.Generic;
using ChildhoodMinistry.Data.Model;
using PagedList;

namespace ChildhoodMinistry.Contracts
{
    public interface IChildhoodService
    {
        List<int> GetNumberOfChildhoods();
        IPagedList<Childhood> GetPage(int? pageNum, int pageSize);
    }
}
