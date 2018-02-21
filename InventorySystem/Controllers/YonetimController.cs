using InventorySystem.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers {

    [Authorize]
    public class YonetimController : Controller {

        ModelContext db = new ModelContext();

        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult BirimEkle() {
            ViewBag.KurumID = new SelectList(db.Kurum, "KurumID", "Adi");
            return View();
        }

        [HttpPost]
        public ActionResult BirimEkle([Bind(Include = "Adi, KurumID")] Birim birim) {
            if (ModelState.IsValid) {
                db.Birim.Add(birim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KurumID = new SelectList(db.Kurum, "KurumID", "Adi", birim.KurumID);
            return View();
        }



        public PartialViewResult KullaniciList(int kullanici = 1, int kurum = 1, int birim = 1) {
            ViewBag.birim = birim;
            ViewBag.kullanici = kullanici;
            ViewBag.kurum = kurum;

            List<Kullanici> k = db.Kullanici.ToList();
            return PartialView("~/Views/Yonetim/Partials/KullaniciList.cshtml", k.ToPagedList(kullanici, 10));
        }

        public PartialViewResult KurumList(int kullanici = 1, int kurum = 1, int birim = 1) {
            ViewBag.birim = birim;
            ViewBag.kullanici = kullanici;
            ViewBag.kurum = kurum;

            List<Kurum> k = db.Kurum.ToList();
            return PartialView("~/Views/Yonetim/Partials/KurumList.cshtml", k.ToPagedList(kurum, 10));
        }

        public PartialViewResult BirimList(int kullanici = 1, int kurum = 1, int birim = 1) {
            ViewBag.birim = birim;
            ViewBag.kullanici = kullanici;
            ViewBag.kurum = kurum;

            List<Birim> b = db.Birim.ToList();

            return PartialView("~/Views/Yonetim/Partials/BirimList.cshtml", b.ToPagedList(birim, 10));
        }


    }
}