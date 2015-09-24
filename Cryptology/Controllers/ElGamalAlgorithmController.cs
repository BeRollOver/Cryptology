using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class ElGamalAlgorithmController : Controller
    {
        // GET: ElGamalEncryption
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
                // вычисление открытого ключа
                long y = Algorithms.HornersMethod(model.G, model.X, model.P);
                
                // Шифрование
                var a = Algorithms.HornersMethod(model.G, model.K, model.P);
                var b = from sim in model.Text.ToCharArray()
                        select Algorithms.HornersMethod(y, model.K, model.P, sim - 1040);

                // Обратное преобразование
                var ax = Algorithms.HornersMethod(a, model.X, model.P);
                var inv_ax = Algorithms.ExtendedGCD(ax, model.P);
                var M = from sim in b
                        select (sim * inv_ax) % model.P + 1040;
                
                ViewBag.Y = y;
                ViewBag.a = a;
                ViewBag.b = b;
                ViewBag.ax = ax;
                ViewBag.inv_ax = inv_ax;
                ViewBag.M = M;

                return View("Echo", model);
            }

            return RedirectToAction("Index");
        }
    }
}