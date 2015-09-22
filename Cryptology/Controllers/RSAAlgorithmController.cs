using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class RSAAlgorithmController : Controller
    {
        // GET: RSAAlgorithm
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RSAAlgorithmModels model)
        {
            if (ModelState.IsValid)
            {
                long Kc;
                long N;
                long F;
                IEnumerable<long> C;
                IEnumerable<long> M;

                // Нахождение модуля и функции Эйлера
                N = model.P * model.Q;
                F = (model.P - 1) * (model.Q - 1);

                if (gcd(F, model.Ko) != 1)
                {
                    return View("Index");
                }

                // Алгоритм вычисления обратного элемента для небольших чисел
                int t;
                for (t = 0; (F * t + 1) % model.Ko != 0; t++) ;
                Kc = (F * t + 1) / model.Ko;

                // Шифрование
                C = from sim in model.Text.ToCharArray()
                    select HornersMethod(sim - 1040, model.Ko, N);

                // Обратное преобразование
                M = from sim in C
                    select HornersMethod(sim, Kc, N) + 1040;

                ViewBag.Kc = Kc;
                ViewBag.N = N;
                ViewBag.F = F;
                ViewBag.C = C;
                ViewBag.M = M;

                return View("Echo", model);
            }

            return RedirectToAction("Index");
        }

        // малый Алгоритм Евклида
        long gcd(long a, long b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }
        
        // схема Горнера
        long HornersMethod(long a, long x, long m)
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