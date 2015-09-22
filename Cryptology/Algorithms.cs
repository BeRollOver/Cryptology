using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cryptology
{
    public static class Algorithms
    {
        // малый Алгоритм Евклида
        public static long GCD(long a, long b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }

        // Алгоритм вычисления обратного элемента для небольших чисел
        public static long InverseElement(long a, long n)
        {
            int t;
            for (t = 0; (n * t + 1) % a != 0; t++) ;
            return (n * t + 1) / a;
        }

        // схема Горнера
        public static long HornersMethod(long a, long x, long m)
        {
            long y = (x % 2 == 1) ? a : 1, r = a;
            if (m == 0) throw new Exception("DivideByZero");
            if (a == 0) return 0;
            if (a == 0 || x == 0) return 1;

            long k = (long)(Math.Log(x) / Math.Log(2));
            if ((Math.Log(x) / Math.Log(2)) % 1D != 0D) k++;
            if (k > 64 || k == 0) throw new Exception("NoAnswer");

            for (int i = 1; i < k; i++)
            {
                r = (r * r) % m;
                if ((x >> i) % 2 == 1) y = (y * r) % m;
            }
            return y;
        }
    }
}