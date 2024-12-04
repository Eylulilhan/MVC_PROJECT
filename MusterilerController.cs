using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MVC_STOK.Models.Entity;

namespace MVC_STOK.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        MVCDbStokEntities db = new MVCDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Tbl_Musteriler select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m=>m.Musteri_Adi.Contains(p));    
            }
            return View(degerler.ToList());  
            //var musteriler = db.Tbl_Musteriler.ToList();

            //return View(musteriler);
        }
        [HttpGet]
        public ActionResult YeniMusteriEkle()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult YeniMusteriEkle(Tbl_Musteriler p1)

        {

            if (!ModelState.IsValid)
            {
                return View("YeniMusteriEkle");
            }
            db.Tbl_Musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult  MusteriSil(int id)
        {
            var urunlerisil = db.Tbl_Musteriler.Find(id);
            db.Tbl_Musteriler.Remove(urunlerisil);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Tbl_Musteriler.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(Tbl_Musteriler p1)
        {
            var musteri = db.Tbl_Musteriler.Find(p1.Musteri_Id);
            musteri.Musteri_Adi = p1.Musteri_Adi;
            musteri.Musteri_Soyadi=p1.Musteri_Soyadi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}