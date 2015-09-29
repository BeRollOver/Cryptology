using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cryptology.Models
{
    public class ChaumBlindSignatureModels : RSAAlgorithmModels
    {
        public long k { get; set; }

        public long N { get { return P * Q; } }

        public long F { get { return (P - 1) * (Q - 1); } }
    }
}