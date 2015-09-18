using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class EuclideanAlgorithmController : Controller
    {
        // GET: EuclideanAlgorithm
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EuclideanAlgorithmModels model)
        {
            if (ModelState.IsValid)
            {
                return View("Echo", model);
            }
            return RedirectToAction("Index");
        }
    }
}