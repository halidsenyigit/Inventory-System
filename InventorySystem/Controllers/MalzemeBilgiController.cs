using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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

        public ActionResult Detay(int? id) {
            if (id == null)
                RedirectToAction("Index");

            MalzemeBilgi mb = db.MalzemeBilgi.FirstOrDefault(n => n.MalzemeBilgiID == id);

            return View(mb);
        }

        public ActionResult Guncelle(int? id) {
            if (id == null)
                RedirectToAction("Index");

            return View();
        }

        public ActionResult Sil(int? id) {
            if (id == null)
                RedirectToAction("Index");

            return View();
        }

        public ActionResult SilOnayla() {
            return RedirectToAction("Index");
        }

    }
}