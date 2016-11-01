using System.Linq;
using PagedList;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.BL
{
    public class ChildhoodService : CrudService<Childhood>, IChildhoodService 
    {
        private readonly IRepository<Childhood> _childhoods;

        public ChildhoodService(IRepository<Childhood> childhoods) : base(childhoods)
        {
            _childhoods = childhoods;
        }

        public Childhood GetChildhoodByNum(int num)
        {
            return _childhoods.GetItems().First(s => s.Number == num);
        }

        public IPagedList<Childhood> GetPage(int? pageNum, int pageSize)
        {
            return _childhoods.GetItems().OrderBy(x => x.Number).ToPagedList((pageNum ?? 1), pageSize);
        }
    }
}
