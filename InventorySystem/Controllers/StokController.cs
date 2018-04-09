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
    public class StokController : Controller {
        ModelContext db = new ModelContext();


        public ActionResult Index(int sayfa = 1, string q = "") {
            var stoks = db.Stok.Where(n => n.SeriNumarasi.Contains(q) || n.MalzemeBilgi.MalzemeAdi.Contains(q) || n.Kurum.Adi.Contains(q)).ToList();
            return View(stoks.ToPagedList(sayfa, 20));
        }


        [Authorize(Roles = "ST")]
        [HttpGet]
        public ActionResult Ekle() {

            String username = User.Identity.Name;
            int userID = db.Kullanici.FirstOrDefault(n => n.KullaniciAdi == username).KullaniciID;
            Kurum kurum = db.Kullanici.FirstOrDefault(n => n.KullaniciID == userID).Birim.Kurum;
            ViewBag.Kurum = kurum.Adi;
            ViewBag.MalzemeBilgiID = new SelectList(db.MalzemeBilgi, "MalzemeBilgiID", "MalzemeAdi");
            return View();
        }

        [Authorize(Roles = "ST")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "MalzemeBilgiID,SeriNumarasi,GarantiTarihBaslangic,GarantiTarihBitis,MalzemeBirimBedeli,Adet,KurumID,Aciklama")] Stok stok) {
            String username = User.Identity.Name;
            int userID = db.Kullanici.FirstOrDefault(n => n.KullaniciAdi == username).KullaniciID;
            Kurum kurum = db.Kullanici.FirstOrDefault(n => n.KullaniciID == userID).Birim.Kurum;

            stok.KurumID = kurum.KurumID;
            if (ModelState.IsValid) {
                db.Stok.Add(stok);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Kurum = kurum.Adi;
            ViewBag.MalzemeBilgiID = new SelectList(db.MalzemeBilgi, "MalzemeBilgiID", "MalzemeAdi");

            return View(stok);
        }

        [Authorize(Roles = "ST")]
        public ActionResult Detay(int? id) {
            if (id == null)
                return RedirectToAction("index");

            Stok stok = db.Stok.FirstOrDefault(n => n.StokID == id);

            return View(stok);
        }

        [HttpGet]
        [Authorize(Roles = "ST")]
        public ActionResult Guncelle(int? id) {
            if (id == null)
                return RedirectToAction("index");

            var stok = db.Stok.Where(n => n.StokID == id).FirstOrDefault();

            String username = User.Identity.Name;
            int userID = db.Kullanici.FirstOrDefault(n => n.KullaniciAdi == username).KullaniciID;
            Kurum kurum = db.Kullanici.FirstOrDefault(n => n.KullaniciID == userID).Birim.Kurum;
            ViewBag.Kurum = kurum.Adi;
            ViewBag.MalzemeBilgi = stok.MalzemeBilgi.MalzemeAdi;

            return View(stok);
        }


        [HttpPost]
        [Authorize(Roles = "ST")]
        [ValidateAntiForgeryToken]
        public ActionResult Guncelle([Bind(Include = "StokID,MalzemeBilgiID,SeriNumarasi,GarantiTarihBaslangic,GarantiTarihBitis,MalzemeBirimBedeli,Adet,KurumID,Aciklama")] Stok stok) {
            String username = User.Identity.Name;
            int userID = db.Kullanici.FirstOrDefault(n => n.KullaniciAdi == username).KullaniciID;
            Kurum kurum = db.Kullanici.FirstOrDefault(n => n.KullaniciID == userID).Birim.Kurum;
            ViewBag.Kurum = kurum.Adi;
            ViewBag.MalzemeBilgiID = new SelectList(db.MalzemeBilgi, "MalzemeBilgiID", "MalzemeAdi");
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "ST")]
        public ActionResult GuncelleOnayla([Bind(Include = "StokID,MalzemeBilgiID,SeriNumarasi,GarantiTarihBaslangic,GarantiTarihBitis,MalzemeBirimBedeli,Adet,KurumID,Aciklama")] Stok stok) {

            String username = User.Identity.Name;
            int userID = db.Kullanici.FirstOrDefault(n => n.KullaniciAdi == username).KullaniciID;
            Kurum kurum = db.Kullanici.FirstOrDefault(n => n.KullaniciID == userID).Birim.Kurum;
            ViewBag.Kurum = kurum.Adi;
            ViewBag.MalzemeBilgi = db.MalzemeBilgi.FirstOrDefault(n => n.MalzemeBilgiID == stok.MalzemeBilgiID).MalzemeAdi;

            Stok eski = db.Stok.FirstOrDefault(n => n.StokID == stok.StokID);
            ViewBag.SeriNumarasi = eski.SeriNumarasi;
            ViewBag.GarantiTarihBaslangic = eski.GarantiTarihBaslangic;
            ViewBag.GarantiTarihBitis = eski.GarantiTarihBitis;
            ViewBag.MalzemeBirimBedeli = eski.MalzemeBirimBedeli;
            ViewBag.Adet = eski.Adet;
            ViewBag.Aciklama = eski.Aciklama;

            return View(stok);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ST")]
        public ActionResult GuncelleOnayli([Bind(Include = "StokID,MalzemeBilgiID,SeriNumarasi,GarantiTarihBaslangic,GarantiTarihBitis,MalzemeBirimBedeli,Adet,KurumID,Aciklama")] Stok stok) {
            String username = User.Identity.Name;
            int userID = db.Kullanici.FirstOrDefault(n => n.KullaniciAdi == username).KullaniciID;
            stok.KurumID = db.Kullanici.FirstOrDefault(n => n.KullaniciID == userID).Birim.Kurum.KurumID;
            if (ModelState.IsValid) {
                db.Entry(stok).State = EntityState.Modified;
                db.SaveChanges();
            } else {
                return Content("hata oluştu");
            }
            return RedirectToAction("Detay", new { id = stok.StokID });
        }


        [Authorize(Roles = "ST")]
        public ActionResult Sil(int? id) {
            Stok stok = db.Stok.FirstOrDefault(n => n.StokID == id);
            if (id == null)
                RedirectToAction("Index");


            return View(stok);
        }

        [Authorize(Roles = "ST")]
        public ActionResult SilOnayla(int? id) {
            
            if (id == null)
                RedirectToAction("Index");


            return RedirectToAction("Index");
        }
    }


}