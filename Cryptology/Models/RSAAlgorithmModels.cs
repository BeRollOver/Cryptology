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
        [Display(Name = "Текст для шифрования: ")]
        [RegularExpression("[а-яА-Я]{3,40}$")]
        public string Text { get; set; } = "";
        [Required]
        [Range(64, long.MaxValue)]
        public long P { get; set; } = 0;
        [Required]
        [Range(0, long.MaxValue)]
        public long Q { get; set; } = 0;
        [Required]
        [Display(Name = "Открытый ключ: ")]
        public long Ko { get; set; } = 0;
    }
}