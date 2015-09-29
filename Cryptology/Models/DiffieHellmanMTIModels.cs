using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cryptology.Models
{
    public class DiffieHellmanModels
    {
        public long p { get; set; }
        public long alpha { get; set; }
        public long x { get; set; }
        public long y { get; set; }
    }
    public class MTIModels : DiffieHellmanModels
    {
        public long a { get; set; }
        public long b { get; set; }
    }
}