using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InventorySystem.Controllers {
    public class AccountController : Controller {
        ModelContext db = new ModelContext();

        public ActionResult Index() {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Login() {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(FormCollection f) {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("index");

            string username = f.Get("username");
            string password = f.Get("password");

            if (db.Kullanici.Any(n => n.KullaniciAdi == username && n.Sifre == password)) {
                FormsAuthentication.RedirectFromLoginPage(username, true);
            }

            ViewBag.Error = "Kullanıcı adı yada şifre hatalı";
            return View();
        }

        [Authorize]
        public ActionResult Profil() {
            return View();
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public ActionResult AuthTest() {

            return View();
        }


    }
}