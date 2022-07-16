using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.EntityFramework;

namespace StokTakip.Controllers
{
    public class UrunlerController : Controller
    {
        private DbStokTakipEntities dbStokTakipEntities = new DbStokTakipEntities();
        // GET: Urunler
        public ActionResult Index()
        {
            var productList = dbStokTakipEntities.Urunler.ToList();
            foreach (var product in productList)
            {
                if (product.UrunKategori == null)
                {
                    product.Kategoriler = new Kategoriler {KategoriAd = "Kategori Yoktur."};
                }
                
            }
            return View(productList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //List<SelectListItem> listItemsKategori = dbStokTakipEntities.Kategoriler.Select(k => new SelectListItem()
            //{
            //    Value = k.KategoriId.ToString(),
            //    Text = k.KategoriAd
            //}).ToList();

            List<SelectListItem> kategoriler =
                (from kategori in dbStokTakipEntities.Kategoriler.ToList()
                 select new SelectListItem()
                 {
                     Text = kategori.KategoriAd,
                     Value = kategori.KategoriId.ToString()
                 }).ToList();

            ViewBag.kategoriler = kategoriler;

            return View();

        }

        [HttpPost]
        public ActionResult Create(Urunler urunler)
        {
            var kategori = dbStokTakipEntities.Kategoriler.Where(k => k.KategoriId == urunler.Kategoriler.KategoriId).FirstOrDefault();
            urunler.Kategoriler = kategori;

            dbStokTakipEntities.Urunler.Add(urunler);
            dbStokTakipEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
        {
            var productToDelete = dbStokTakipEntities.Urunler.Find(productId);
            dbStokTakipEntities.Urunler.Remove(productToDelete);
            dbStokTakipEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int productId)
        {
            var productToUpdate = dbStokTakipEntities.Urunler.Find(productId);

            List<SelectListItem> kategoriler =
                (from kategori in dbStokTakipEntities.Kategoriler.ToList()
                    select new SelectListItem()
                    {
                        Text = kategori.KategoriAd,
                        Value = kategori.KategoriId.ToString()
                    }).ToList();

            ViewBag.kategoriler = kategoriler;

            return View(productToUpdate);
        }

        [HttpPost]
        public ActionResult Update(Urunler urun)
        {
            var kategori = dbStokTakipEntities.Kategoriler.Where(p => p.KategoriId == urun.Kategoriler.KategoriId)
                .FirstOrDefault();
            urun.UrunKategori = kategori?.KategoriId;

            var productToUpdate = dbStokTakipEntities.Urunler.Find(urun.UrunId);
            productToUpdate.UrunAd = urun.UrunAd;
            productToUpdate.UrunKategori = urun.UrunKategori;
            productToUpdate.Fiyat =urun.Fiyat;
            productToUpdate.Marka =urun.Marka;
            productToUpdate.Stok = urun.Stok;

            dbStokTakipEntities.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}