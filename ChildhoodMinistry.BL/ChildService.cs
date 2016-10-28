using System.Collections.Generic;
using System.Linq;
using PagedList;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.BL
{
    public class ChildService : CrudService<Child>, IChildService
    {
        private readonly IRepository<Child> _children;

        public ChildService(IRepository<Child> children) : base (children)
        {
            _children = children;
        }
        
        public IPagedList<Child> GetPage(int? pageNum, int pageSize)
        {
            return _children.GetItems().OrderBy(x => x.Surname).ToPagedList((pageNum ?? 1), pageSize);
        }
    }
}
