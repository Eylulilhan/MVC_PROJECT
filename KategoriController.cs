using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_STOK.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_STOK.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCDbStokEntities db = new MVCDbStokEntities();//modelimizin içindeki tablolara ulaşmak için db adında bir nesne türettik.
        public ActionResult Index(int sayfa=1)
        {
            /*  var degerler = db.Tbl_Kategoriler.ToList();*///değerler adında bir değişken tanımlandı ve Tbl_Kategorilerdeki değerleri bu değişkene atadık ve bize listelemesini istedik.
            var degerler = db.Tbl_Kategoriler.ToList().ToPagedList(sayfa,2);
            return View(degerler);// sonuç olarak bize değerler değişkenine atadığımız değelerleri bize bir view sayfasında göstersin.
        }
        [HttpGet]
        public ActionResult YeniKategori()//SAYFA YÜKLENİNCE BUNU YAP.
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(Tbl_Kategoriler p1)//BEN BİR ŞEYE TIKLAYINCA BUNU YAP.
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tbl_Kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tbl_Kategoriler.Find(id);
            return View("KategoriGetir", ktgr);//Bana bir view sayfası döndür bu view sayfasının içinde kategoriGetir methodunun içindeki  ktgr bilgileri getir.
        }
        public ActionResult Guncelle(Tbl_Kategoriler p1)
        {
            var ktg = db.Tbl_Kategoriler.Find(p1.Kategoi_Id);
            ktg.Kategori_Adi = p1.Kategori_Adi;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}