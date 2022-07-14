using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.EntityFramework;

namespace StokTakip.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        private DbStokTakipEntities dbStokTakipEntities = new DbStokTakipEntities();
        public ActionResult Index()
        {
            var customerList = dbStokTakipEntities.Musteriler.ToList();
            return View(customerList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Musteriler musteriler)
        {
            dbStokTakipEntities.Musteriler.Add(musteriler);
            dbStokTakipEntities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}