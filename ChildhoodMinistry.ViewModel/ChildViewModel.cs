﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChildhoodMinistry.ViewModel
{
    public class ChildViewModel
    {
        public int Ind { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("[А-я]{2,}",ErrorMessage = "Имя: Кириллица не короче двух символов")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("[А-я]{2,}", ErrorMessage = "Фамилия: Кириллица не короче двух символов")]
        public string Surname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("[А-я]{2,}", ErrorMessage = "Отчество: Кириллица не короче двух символов")]
        public string Patronymic { get; set; }
        [Range(3,10,ErrorMessage = "Возраст: от 3 до 10 лет")]
        public int Age { get; set; }
        [Required]
        public int ChildhoodNum { get; set; }    
    }
}