using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.Web
{
    public class Paging<T>
    {
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalItems { get; set; }
        public int totalPages
        {
            get { return (int)Math.Ceiling((decimal)totalItems / pageSize); }
        }
        public List<T> data { get; set; }
    }
}
