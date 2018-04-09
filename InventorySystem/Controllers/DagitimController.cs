using InventorySystem.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    [Authorize]
    public class DagitimController : Controller
    {
        ModelContext db = new ModelContext();

        [Authorize(Roles = "DT")]
        public ActionResult Index(int sayfa = 1, string q = "")
        {
            int birimID = db.Kullanici.FirstOrDefault(n => n.KullaniciAdi == User.Identity.Name).BirimID;
            var dagitim = db.Dagitim.Where(n => n.BirimID == birimID && (n.EvrakSayi.Contains(q))).ToList();

            return View(dagitim.ToPagedList(sayfa, 20));
        }
    }
}