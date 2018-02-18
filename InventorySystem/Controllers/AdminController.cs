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
        public ActionResult Index()
        {
            
            return View();
        }
    }
}