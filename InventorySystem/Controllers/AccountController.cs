using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("index", "Admin");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login() {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(FormCollection data) {

            return View();
        }

        [Authorize]
        public ActionResult AuthTest() {

            return View();
        }


    }
}