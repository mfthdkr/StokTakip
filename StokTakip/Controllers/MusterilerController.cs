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
        public ActionResult Index(string searchingKey)
        {
            var result = from entity in dbStokTakipEntities.Musteriler select entity;
            if (!string.IsNullOrEmpty(searchingKey))
            {
                result = result.Where(p => p.MusteriAd.Contains(searchingKey));
            }
            return View(result.ToList());
        }

        public ActionResult Create()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Create(Musteriler musteriler)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbStokTakipEntities.Musteriler.Add(musteriler);
            dbStokTakipEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CustomerId)
        {
            
            var customerToDelete = dbStokTakipEntities.Musteriler.Find(CustomerId);
            dbStokTakipEntities.Musteriler.Remove(customerToDelete);
            dbStokTakipEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int customerId)
        {
            var categoryToUpdate = dbStokTakipEntities.Musteriler.Find(customerId);

            return View(categoryToUpdate);
        }

        [HttpPost]
        public ActionResult Update(Musteriler customer)
        {
            var customerToUpdate = dbStokTakipEntities.Musteriler.Find(customer.MusteriId);
            customerToUpdate.MusteriAd = customer.MusteriAd;
            customerToUpdate.MusteriSoyad = customer.MusteriSoyad;
            dbStokTakipEntities.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}