using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cryptology.Models
{
    public class RSAAlgorithmModels
    {
        [Required]
        [Display(Name = "Текст для шифрования: ")]
        [RegularExpression("[а-яА-Я]{3,40}$")]
        public string Text { get; set; }
        [Required]
        public long P { get; set; }
        [Required]
        public long Q { get; set; }
        [Required]
        [Display(Name = "Открытый ключ: ")]
        public long Ko { get; set; }
    }
}