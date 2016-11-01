using System.Collections.Generic;
using ChildhoodMinistry.Web.Model;
using PagedList;

namespace ChildhoodMinistry.Web.Builders
{
    public class PageBuilder<T>
    {
        public PageViewModel<T> BuildPage(IPagedList pageList, List<T> items)
        {
            var page = new Pager
            {
                CurrentPage = pageList.PageNumber,
                PageSize = pageList.PageSize,
                TotalItems = pageList.TotalItemCount
            };
            var result = new PageViewModel<T>
            {
                Data = items,
                Page = page
            };
            return result;
        }

    }
}