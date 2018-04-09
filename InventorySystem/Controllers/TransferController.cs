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
    public class TransferController : Controller
    {
        ModelContext db = new ModelContext();
        [Authorize(Roles = "TR")]
        public ActionResult Index(int sayfa = 1)
        {
            var transfer = db.Transfer.ToList();
            return View(transfer.ToPagedList(sayfa, 20));
        }
    }
}