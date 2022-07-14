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

        public ActionResult Delete(int categoryId)
        {
            var categoryToDelete = dbStokTakipEntities.Kategoriler.Find(categoryId);
            dbStokTakipEntities.Kategoriler.Remove(categoryToDelete);
            dbStokTakipEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int categoryId)
        {
            var categoryToUpdate = dbStokTakipEntities.Kategoriler.Find(categoryId);

            return View(categoryToUpdate);
        }

        [HttpPost]
        public ActionResult Update(Kategoriler category)
        {
            var categoryToUpdate =
                dbStokTakipEntities.Kategoriler.Find(category.KategoriId);
            categoryToUpdate.KategoriAd = category.KategoriAd;
            dbStokTakipEntities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}