using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class ElGamalEncryptionController : Controller
    {
        // GET: ElGamalEncryption
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ElGamalEncryptionModels model)
        {
            if (ModelState.IsValid)
            {
                var algs = new RSAAlgorithmController();

                // Проверяем, подходит ли выбранное число K
                if (algs.GCD(model.K, model.P - 1) != 1)
                {
                    return View("Index");
                }
                // вычисление открытого ключа
                long y = algs.HornersMethod(model.G, model.X, model.P);


                // Шифрование
                var a = algs.HornersMethod(model.G, model.K, model.P);
                var b = from sim in model.Text.ToCharArray()
                    select (algs.HornersMethod(y, model.K, model.P) * sim - 1040) % model.P;

                List<long> C = new List<long>() { a };
                C.AddRange(b);

                // Обратное преобразование
                //var inv_a = algs.InverseElement(a)
                //var M = from sim in C
                //    select HornersMethod(sim, Kc, N) + 1040;

                ViewBag.Y = y;

                return View("View", model);
            }

            return RedirectToAction("Index");
        }
    }
}