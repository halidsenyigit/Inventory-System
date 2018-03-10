using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace InventorySystem.Controllers
{

    [Authorize]
    public class MalzemeBilgiController : Controller
    {
        ModelContext db = new ModelContext();

        
        public ActionResult Index(int sayfa=1, string q="")
        {
            List<MalzemeBilgi> mb = db.MalzemeBilgi.Where(n => n.MalzemeAdi.Contains(q) || n.MalzemeKodu == q || n.OrijinalStokKodu == q || n.AmbarYazilimKodu == q).ToList();
            return View(mb.ToPagedList(sayfa, 20));
        }

        [Authorize(Roles = "MB")]
        [HttpGet]
        public ActionResult Ekle() {
            return View();
        }

        [Authorize(Roles = "MB")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "MalzemeKodu,MalzemeAdi,MalzemeTanimi,OrijinalStokKodu,TeknikBilgi,AmbarYazilimKodu,Aciklama")] MalzemeBilgi malzemeBilgi) {
            
            if (ModelState.IsValid) {
                db.MalzemeBilgi.Add(malzemeBilgi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(malzemeBilgi);
        }

        public ActionResult Detay(int? id) {
            if (id == null)
                RedirectToAction("Index");

            MalzemeBilgi mb = db.MalzemeBilgi.FirstOrDefault(n => n.MalzemeBilgiID == id);

            return View(mb);
        }

        [Authorize(Roles = "MB")]
        [HttpGet]
        public ActionResult Guncelle(int? id) {
            if (id == null)
                RedirectToAction("Index");
            MalzemeBilgi mb = db.MalzemeBilgi.FirstOrDefault(n => n.MalzemeBilgiID == id);
            return View(mb);
        }

        [Authorize(Roles = "MB")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Guncelle([Bind(Include = "MalzemeBilgiID,MalzemeKodu,MalzemeAdi,MalzemeTanimi,OrijinalStokKodu,TeknikBilgi,AmbarYazilimKodu,Aciklama")] MalzemeBilgi malzemeBilgi) {

            if (ModelState.IsValid) {
                db.Entry(malzemeBilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(malzemeBilgi);
        }


        [Authorize(Roles = "MB")]
        public ActionResult Sil(int? id) {
            if (id == null)
                RedirectToAction("Index");

            List<Stok> iliskiliStoklar = db.Stok.Where(n => n.MalzemeBilgiID == id).ToList();
            return View(iliskiliStoklar);
        }

        [Authorize(Roles = "MB")]
        public ActionResult SilOnayla(int? id) {
            if (id == null)
                RedirectToAction("Index");

            List<Stok> stoklar = db.Stok.Where(n => n.MalzemeBilgiID == id).ToList();
            db.Stok.RemoveRange(stoklar);
            db.MalzemeBilgi.Remove(db.MalzemeBilgi.FirstOrDefault(n => n.MalzemeBilgiID == id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}