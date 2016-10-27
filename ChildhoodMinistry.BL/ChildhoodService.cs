using System.Collections.Generic;
using System.Linq;
using PagedList;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.BL
{
    public class ChildhoodService : IChildhoodService
    {
        private readonly IRepository<Childhood> _childhoods;

        public ChildhoodService(IRepository<Childhood> childhoods)
        {
            _childhoods = childhoods;            
        }

        public List<int> GetNumberOfChildhoods()
        {
            return (from nums in _childhoods.GetItems()
                    orderby nums.Number
                    select nums.Number).ToList();
        }

        public IPagedList<Childhood> GetPage(int? pageNum, int pageSize)
        {
            return _childhoods.GetItems().OrderBy(x => x.Number).ToPagedList((pageNum ?? 1), pageSize);
        }
    }
}
