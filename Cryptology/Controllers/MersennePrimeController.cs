using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;

namespace Cryptology.Controllers
{
    public class MersennePrimeController : Controller
    {
        // GET: MersennePrimzahl
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MersennePrimeModel model)
        {
            return View("Echo", model);
        }
    }
}