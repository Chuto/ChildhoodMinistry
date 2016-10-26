using System;
using System.Collections.Generic;

namespace ChildhoodMinistry.Web.Model
{
    public class PageViewModel<T>
    {
        public List<T> Data { get; set; }
        public Pager Page { get; set; } 
    }


    public class Pager
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}
