using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.Data.Models
{
    public class Childhood : BaseEntity
    {
        public int Number { get; set; }
        public string Adress { get; set; }
    }
}
