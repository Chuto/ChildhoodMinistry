using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChildhoodMinistry.Web
{
    public class ChildhoodViewModel
    {
        public int Ind { get; set; }
        [Required]
        public int Number { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"\D{2,}\s\d+",ErrorMessage = "Адрес: <название кириллицей> <номер>")]
        public string Adress { get; set; }
    }
}
