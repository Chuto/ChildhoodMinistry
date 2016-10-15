using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.DAL.Models
{
    public class Childhood : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Adress { get; set; }
    }
}
