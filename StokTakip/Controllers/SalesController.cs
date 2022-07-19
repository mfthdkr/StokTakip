using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.EntityFramework;

namespace StokTakip.Controllers
{
    public class SalesController : Controller
    {
        private DbStokTakipEntities dbStokTakipEntities = new DbStokTakipEntities();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSale(Satislar satis)
        {
            dbStokTakipEntities.Satislar.Add(satis);
            dbStokTakipEntities.SaveChanges();

            return View("Index");
        }
    }
}