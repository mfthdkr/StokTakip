using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.EntityFramework;

namespace StokTakip.Controllers
{
    public class KategorilerController : Controller
    {
        private DbStokTakipEntities dbStokTakipEntities = new DbStokTakipEntities();

        // GET: Kategori
        public ActionResult Index()
        {
           var result= dbStokTakipEntities.Kategoriler.ToList();

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kategoriler kategoriler)
        {
            dbStokTakipEntities.Kategoriler.Add(kategoriler);
            dbStokTakipEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}