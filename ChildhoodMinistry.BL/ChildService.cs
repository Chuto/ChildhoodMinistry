using System.Linq;
using PagedList;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;
using System.Collections.Generic;

namespace ChildhoodMinistry.BL
{
    public class ChildService : CrudService<Child>, IChildService
    {
        private readonly IRepository<Child> _children;

        public ChildService(IRepository<Child> children) : base (children)
        {
            _children = children;
        }

        public IList<Child> GetChildrenByChildhoodId(int id)
        {
            return _children.GetItems().Where(s => s.ChildhoodId == id).ToList();
        }

        public IPagedList<Child> GetPage(int? pageNum, int pageSize)
        {
            return _children.GetItems().OrderBy(x => x.Surname).ToPagedList((pageNum ?? 1), pageSize);
        }
    }
}
