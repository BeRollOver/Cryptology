using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class ElGamalSAController : Controller
    {
        // GET: ElGamalSA
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ElGamalAlgorithmModels model)
        {
            if (ModelState.IsValid)
            {
                if (model.G >= model.P || model.X >= model.P)
                    return View("Index");

                List<long> KList = new List<long>();

                for (int i = 2; i < model.P - 1; i++)
                    if (Algorithms.GCD(i, model.P - 1) == 1)
                        KList.Add(i);

                ViewBag.KList = KList;
                return View("Input", model);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Input(ElGamalAlgorithmModels model)
        {
            if (ModelState.IsValid)
            {
                long m = 0;
                long A1 = 0;
                long A2 = 0;

                // вычисление открытого ключа
                long y = Algorithms.HornersMethod(model.G, model.X, model.P);

                // вычисление хэша
                for (int i = 0; i < model.Text.ToCharArray().Count(); i++)
                {
                    m ^= Algorithms.HornersMethod(model.Text.ToCharArray()[i] - 1040, y, model.P);
                    m %= model.P;
                }

                // вычисление цифровой подписи
                var a = Algorithms.HornersMethod(model.G, model.K, model.P);
                var inv_K = Algorithms.ExtendedGCD(model.K, model.P - 1);
                var b = (inv_K * (m - a * model.X)) % (model.P - 1);
                if (b < 0) b += model.P - 1;

                // вычисление первой оценки
                A1 = Algorithms.HornersMethod(model.G, m, model.P);
                A2 = (Algorithms.HornersMethod(y, a, model.P) * Algorithms.HornersMethod(a, b, model.P)) % model.P;

                ViewBag.Y = y;
                ViewBag.a = a;
                ViewBag.inv_K = inv_K;
                ViewBag.b = b;
                ViewBag.A1 = A1;
                ViewBag.A2 = A2;

                if(A1 == A2)
                    return View("Echo", model);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}