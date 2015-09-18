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
        public string TextA { get; set; }
        [Required]
        public long P { get; set; }
        [Required]
        public long Q { get; set; }
        [Required]
        [Display(Name = "Открытый ключ: ")]
        public long Ko { get; set; }
        
        public long N { get; private set; }
        public long F { get; private set; }
        
        public void Set()
        {
            N = P * Q;
            F = (P - 1) * (Q - 1);
        }
    }
}