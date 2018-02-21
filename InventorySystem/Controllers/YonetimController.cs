using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers {
    public class YonetimController : Controller {

        ModelContext db = new ModelContext();

        public ActionResult Index() {

            return View();
        }


        public PartialViewResult KullaniciList() {
            List<Kullanici> k = db.Kullanici.ToList();
            return PartialView("~/Views/Yonetim/Partials/KullaniciList.cshtml", k);
        }

        public PartialViewResult KurumList() {
            List<Kurum> k = db.Kurum.ToList();
            return PartialView("~/Views/Yonetim/Partials/KurumList.cshtml", k);
        }

        public PartialViewResult BirimList() {
            List<Birim> b = db.Birim.ToList();
            return PartialView("~/Views/Yonetim/Partials/BirimList.cshtml", b);
        }


    }
}