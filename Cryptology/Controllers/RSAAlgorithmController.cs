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
                model.Set();
                if (gcd(model.F, model.Ko) != 1)
                {
                    return Content("Неправильный открытый ключ!");
                }
                return View("Echo", model);
            }
            return RedirectToAction("Index");
        }

        long gcd(long a, long b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }
    }
}