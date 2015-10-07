using BigInteger103;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptology.Models;
using System.Text;

namespace Cryptology.Controllers
{
    public class GOST34102012Controller : Controller
    {
        // GET: GOST34102012
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(GOST34102012Models model)
        {
            BigInteger p = model.p;
            BigInteger a = model.a;
            BigInteger b = model.b;
            byte[] xG = model.xG;
            BigInteger n = model.n;
            DSGost DS = new DSGost(p, a, b, n, xG);
            BigInteger d = DS.GenPrivateKey(192, model.Seed);
            ECPoint Q = DS.GenPublicKey(d);
            Stribog hash = new Stribog(256);
            byte[] H = hash.GetHash(Encoding.Default.GetBytes(model.Text));
            string sign = DS.SignGen(H, d);
            bool result = DS.SignVer(H, sign, Q);

            ViewBag.d = d;
            ViewBag.Q = Q;
            ViewBag.H = H;
            ViewBag.alpha = DS.alpha;
            ViewBag.e = DS.e;
            ViewBag.k = DS.k;
            ViewBag.C = DS.C;
            ViewBag.r = DS.r;
            ViewBag.s = DS.s;
            ViewBag.sign = sign;

            ViewBag.n = DS.n;
            ViewBag.encr_r = DS.encr_r;
            ViewBag.encr_s = DS.encr_s;
            ViewBag.encr_alpha = DS.encr_alpha;
            ViewBag.encr_e = DS.encr_e;
            ViewBag.v = DS.v;
            ViewBag.z1 = DS.z1;
            ViewBag.z2 = DS.z2;
            ViewBag.A = DS.A;
            ViewBag.B = DS.B;
            ViewBag.R = DS.R;
            ViewBag.encr_C = DS.encr_C;

            return View("Echo", model);
        }
    }
}