using ChildhoodMinistry.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.BL
{
    public interface IChildhoodService : ICRUDService<ChildhoodViewModel>
    {
        List<int> GetChildhoodNum();
    }
}
