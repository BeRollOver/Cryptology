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

        // расширенный Алгоритм Евклида
        public static long ExtendedGCD(long a, long n)
        {
            long[] u = new long[] { 0, 1, n };
            long[] v = new long[] { 1, 0, a };
            long q, t;

            while (u[2] != 1 && u[2] != 0 && v[2] != 0)
            {
                q = u[2] / v[2];
                for (int i = 0; i < 3; i++)
                {
                    t = u[i] - q * v[i];
                    u[i] = v[i];
                    v[i] = t;
                }
            }
            if (u[0] < 0) u[0] = n + u[0];

            if (u[2] == 1)
            {
                return u[0];
            }

            return 0;
        }

        // Алгоритм вычисления обратного элемента для небольших чисел
        public static long InverseElement(long a, long n)
        {
            int t;
            for (t = 0; (n * t + 1) % a != 0; t++) ;
            return (n * t + 1) / a;
        }

        // схема Горнера
        public static long HornersMethod(long a, long x, long m, long n = 1)
        {
            long y = (x % 2 == 1) ? a : 1, r = a;
            if (m == 0) throw new Exception("DivideByZero");
            if (a == 0) return 0;
            if (a == 0 || x == 0) return 1;

            long k = (long)(Math.Log(x) / Math.Log(2));
            if ((Math.Log(x) / Math.Log(2)) % 1D != 0D) k++;
            //if (k > 64 || k == 0) throw new Exception("NoAnswer");

            for (int i = 1; i < k; i++)
            {
                r = (r * r) % m;
                if (i == k - 1)
                    r *= n;
                if ((x >> i) % 2 == 1) y = (y * r) % m;
            }
            return y;
        }

        // шестнадцатиречную строку в массив байтов
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}