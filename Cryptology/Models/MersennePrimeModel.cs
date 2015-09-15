using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cryptology.Models
{
    public class MersennePrimeModel
    {
        [Range(3, 64, ErrorMessage = "Пожалуйста, введите число от 3 до 64")]
        public int p { get; set; }
    }
}