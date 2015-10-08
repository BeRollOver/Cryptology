using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class DiffieHellmanController : Controller
    {
        // GET: DiffieHellman
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DiffieHellmanModels model)
        {
            // Пользователь A формирует сообщение
            long mesA = Algorithms.HornersMethod(model.alpha, model.x, model.p);

            // Пользователь B формирует сообщение
            long mesB = Algorithms.HornersMethod(model.alpha, model.y, model.p);

            // Вычисление общего ключа пользователем A
            long kA = Algorithms.HornersMethod(mesB, model.x, model.p);

            // Вычисление общего ключа пользователем B
            long kB = Algorithms.HornersMethod(mesA, model.y, model.p);

            ViewBag.mesA = mesA;
            ViewBag.mesB = mesB;
            ViewBag.kA = kA;
            ViewBag.kB = kB;

            return View("Input", new MTIModels { p = model.p, alpha = model.alpha, x = model.x, y = model.y });
        }
        [HttpPost]
        public ActionResult Input(MTIModels model)
        {
            // Сторона A формирует сообщение
            long mesA = Algorithms.HornersMethod(model.alpha, model.x, model.p);
            long zA = Algorithms.HornersMethod(model.alpha, model.a, model.p);

            // Сторона B формирует сообщение
            long mesB = Algorithms.HornersMethod(model.alpha, model.y, model.p);
            long zB = Algorithms.HornersMethod(model.alpha, model.b, model.p);

            // Вычисление общего ключа пользователем A
            long kA = (Algorithms.HornersMethod(zB, model.x, model.p) * Algorithms.HornersMethod(mesB, model.a, model.p)) % model.p;

            // Вычисление общего ключа пользователем B
            long kB = (Algorithms.HornersMethod(zA, model.y, model.p) * Algorithms.HornersMethod(mesA, model.b, model.p)) % model.p;

            ViewBag.mesA = mesA;
            ViewBag.mesB = mesB;
            ViewBag.zA = zA;
            ViewBag.zB = zB;
            ViewBag.kA = kA;
            ViewBag.kB = kB;

            return View("Echo", model);
        }
    }
}