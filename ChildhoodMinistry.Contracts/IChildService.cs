﻿using System.Collections.Generic;
using ChildhoodMinistry.Data.Model;
using PagedList;

namespace ChildhoodMinistry.Contracts
{
    public interface IChildService
    {
        List<Child> GetChildByChildhoodId(int id);
        IPagedList<Child> GetPage(int? pageNum, int pageSize);
    }
}