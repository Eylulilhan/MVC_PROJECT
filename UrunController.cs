using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_STOK.Models.Entity;

namespace MVC_STOK.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCDbStokEntities db = new MVCDbStokEntities();
        public ActionResult Index()

        {
            var urunler = db.Tbl_Urunler.ToList();

            return View(urunler);
        }
        [HttpGet]//GET sayfa yüklendiğinde çalışan kodlardır.
        public ActionResult YeniUrunEkle()
        {
            List<SelectListItem> urunler = (from i in db.Tbl_Kategoriler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Kategori_Adi,
                                                Value = i.Kategoi_Id.ToString()
                                            }).ToList();
            ViewBag.dgr = urunler;//ViewBag controllerden Viewlere veri taşıma işlemi için kullanılır.
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrunEkle(Tbl_Urunler P1)
        {
            var ktg = db.Tbl_Kategoriler.Where(m => m.Kategoi_Id == P1.Tbl_Kategoriler.Kategoi_Id).FirstOrDefault();
            P1.Tbl_Kategoriler = ktg;
            db.Tbl_Urunler.Add(P1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urunsil = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(urunsil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.Tbl_Urunler.Find(id);
            List<SelectListItem> urunler = (from i in db.Tbl_Kategoriler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Kategori_Adi,
                                                Value = i.Kategoi_Id.ToString()
                                            }).ToList();
            ViewBag.dgr = urunler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(Tbl_Urunler p)
        {
            var urun = db.Tbl_Urunler.Find(p.Urun_Id);
            urun.Urun_Ad = p.Urun_Ad;
            //urun.Urun_Kategori = p.Urun_Kategori;

            var ktg = db.Tbl_Kategoriler.Where(m => m.Kategoi_Id == p.Tbl_Kategoriler.Kategoi_Id).FirstOrDefault();
            urun.Urun_Kategori= ktg.Kategoi_Id;
            urun.Fiyat = p.Fiyat;
            urun.Stok = p.Stok;
            urun.Marka = p.Marka;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}