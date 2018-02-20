using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class AdminController : Controller
    {
        ModelContext db = new ModelContext();

        // GET: Admin
        [Authorize(Roles = "TR")]
        public ActionResult Index()
        {
            
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