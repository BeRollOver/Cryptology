using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cryptology.Models
{
    public class EuclideanAlgorithmModels
    {
        [Required()]
        [Range(2,double.MaxValue)]
        public int a { get; set; }

        [Required()]
        [Range(2, double.MaxValue)]
        public int n { get; set; }
    }
}