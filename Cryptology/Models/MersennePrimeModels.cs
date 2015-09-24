using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cryptology.Models
{
    public class MersennePrimeModels
    {
        [Range(3, 32, ErrorMessage = "Пожалуйста, введите число от 3 до 32")]
        [Required()]
        public uint p { get; set; }
    }
}