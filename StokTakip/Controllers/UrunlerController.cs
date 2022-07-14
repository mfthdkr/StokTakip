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
    }
}