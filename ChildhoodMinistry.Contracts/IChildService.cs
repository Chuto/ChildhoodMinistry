using ChildhoodMinistry.Data.Model;
using PagedList;

namespace ChildhoodMinistry.Contracts
{
    public interface IChildService : ICrudService<Child>
    {
        IPagedList<Child> GetPage(int? pageNum, int pageSize);
    }
}
