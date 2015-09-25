using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;


namespace Cryptology.Controllers
{
    public class RSASAController : Controller
    {
        // GET: RSASA
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
                long m = 0;
                long m1 = 0;
                long m2 = 0;

                // Нахождение модуля и функции Эйлера
                N = model.P * model.Q;
                F = (model.P - 1) * (model.Q - 1);

                if (Algorithms.GCD(F, model.Ko) != 1)
                {
                    return View("Index");
                }

                // Секретный ключ
                Kc = Algorithms.InverseElement(model.Ko, F);

                // Вычисляем хэш
                for (int i = 0; i < model.Text.ToCharArray().Count(); i++)
                {
                    m ^= Algorithms.HornersMethod(model.Text.ToCharArray()[i] - 1040, model.Ko, N);
                }

                // Вычисляем ЭЦП
                long S = Algorithms.HornersMethod(m, Kc, N);

                // Получение первой оценки
                for (int i = 0; i < model.Text.ToCharArray().Count(); i++)
                {
                    m1^= Algorithms.HornersMethod(model.Text.ToCharArray()[i] - 1040, model.Ko, N);
                }
                
                // Получение второй оценки
                m2 = Algorithms.HornersMethod(S, model.Ko, N);

                ViewBag.Kc = Kc;
                ViewBag.N = N;
                ViewBag.F = F;
                ViewBag.m = m;
                ViewBag.S = S;
                ViewBag.m1 = m1;
                ViewBag.m2 = m2;

                if(m1 == m2)
                    return View("Echo", model);
            }

            return RedirectToAction("Index");
        }
    }
}