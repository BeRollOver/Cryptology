using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cryptology.Models
{
    public class ElGamalEncryptionModels
    {
        [Required]
        [Display(Name = "Текст для шифрования: ")]
        [RegularExpression("[а-яА-Я]{3,40}$")]
        public string Text { get; set; }
        [Required]
        public long K { get; set; }
        [Required]
        public long P { get; set; }
        [Required]
        public long G { get; set; }
        [Required]
        public long X { get; set; }
    }
}