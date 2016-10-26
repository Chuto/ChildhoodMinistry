using System.ComponentModel.DataAnnotations;

namespace ChildhoodMinistry.Web.Model
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
