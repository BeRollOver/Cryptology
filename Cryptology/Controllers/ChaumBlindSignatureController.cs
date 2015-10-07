using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class ChaumBlindSignatureController : Controller
    {
        // GET: ChaumBlindSignature
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ChaumBlindSignatureModels model)
        {
            if (ModelState.IsValid)
            {
                if (Algorithms.GCD(model.F, model.Ko) != 1)
                {
                    return View("Index");
                }

                List<long> KList = new List<long>();

                // Выбираем все возможные числа k
                for (int i = 2; i < model.N; i++)
                    if (Algorithms.GCD(i, model.N) == 1)
                        KList.Add(i);

                ViewBag.KList = KList;

                ViewBag.Kc = Algorithms.ExtendedGCD(model.Ko, model.F);

                return View("Input", model);
            }

            return View();
        }
        [HttpPost]
        public ActionResult Input(ChaumBlindSignatureModels model)
        {
            long m = 0;
            long inv_k = 0;
            long m1 = 0;
            long s1 = 0;
            long s = 0;

            // Сторона B
            long Kc = Algorithms.ExtendedGCD(model.Ko, model.F);

            // Сторона A 
            // вычисление хэша
            for (int i = 0; i < model.Text.ToCharArray().Count(); i++)
            {
                m ^= Algorithms.HornersMethod(model.Text.ToCharArray()[i] - 1040, model.Ko, model.N);
                m %= model.N;
            }

            // находим обратный элемент k
            inv_k = Algorithms.ExtendedGCD(model.k, model.N);

            // Вычисляем замаскированное сообщение
            m1 = Algorithms.HornersMethod(model.k, model.Ko, model.N, m);

            // Сторона B 
            s1 = Algorithms.HornersMethod(m1, Kc, model.N);

            // Сторона A 
            s = (inv_k * s1) % model.N;

            ViewBag.Kc = Kc;
            ViewBag.inv_k = inv_k;
            ViewBag.m1 = m1;
            ViewBag.s1 = s1;
            ViewBag.s = s;

            return View("Echo", model);
        }
    }
}