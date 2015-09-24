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

                if (Algorithms.GCD(F, model.Ko) != 1)
                {
                    return View("Index");
                }

                // Секретный ключ
                Kc = Algorithms.InverseElement(model.Ko, F);

                // Шифрование
                C = from sim in model.Text.ToCharArray()
                    select Algorithms.HornersMethod(sim - 1040, model.Ko, N);

                // Обратное преобразование
                M = from sim in C
                    select Algorithms.HornersMethod(sim, Kc, N) + 1040;

                ViewBag.Kc = Kc;
                ViewBag.N = N;
                ViewBag.F = F;
                ViewBag.C = C;
                ViewBag.M = M;

                return View("Echo", model);
            }

            return RedirectToAction("Index");
        }
    }
}