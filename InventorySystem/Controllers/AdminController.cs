using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ModelContext db = new ModelContext();

        public ActionResult Index()
        {
            
            return View();
        }

        


        public ActionResult SonIslemBilgisi(int info, string returnUrl, string msg = "") {
            // info =>  1=eklendi, 2=silindi, 3=güncellendi
            ViewBag.info = info;
            
            return View();
        }

        public PartialViewResult UserProfil() {
            string username = User.Identity.Name;
            Kullanici user = db.Kullanici.First(n => n.KullaniciAdi == username);
            return PartialView("~/Views/Shared/Partials/UserProfil.cshtml", user);
        }

        public PartialViewResult Menu() {
            string username = User.Identity.Name;
            Kullanici user = db.Kullanici.First(n => n.KullaniciAdi == username);

            return PartialView("~/Views/Shared/Partials/Menu.cshtml", user);
        }

    }
}