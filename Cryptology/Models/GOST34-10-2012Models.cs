using System;
using System.Collections.Generic;
using System.Linq;
using BigInteger103;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cryptology.Models
{
    public class GOST34102012Models
    {
        public BigInteger p { get; } = new BigInteger("6277101735386680763835789423207666416083908700390324961279", 10);
        public BigInteger a { get; } = new BigInteger("-3", 10);
        public BigInteger b { get; } = new BigInteger("64210519e59c80e70fa7e9ab72243049feb8deecc146b9b1", 16);
        public byte[] xG { get; } = Algorithms.StringToByteArray("03188da80eb03090f67cbf20eb43a18800f4ff0afd82ff1012");
        public BigInteger n { get; } = new BigInteger("ffffffffffffffffffffffff99def836146bc9b1b4d22831", 16);

        [Display(Name = "Сообщение")]
        public string Text { get; set; }
        [Display(Name = "Семя для генерации d")]
        public int Seed { get; set; }
    }
}