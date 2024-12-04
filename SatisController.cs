using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_STOK.Models.Entity;

namespace MVC_STOK.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MVCDbStokEntities db = new MVCDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Tbl_Satis p)//Satışlar tablosundan p adında bir nesne türettik.
        {
            db.Tbl_Satis.Add(p);
            db.SaveChanges();
            return View("Index");  
        }

    }
}