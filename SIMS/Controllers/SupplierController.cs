using FC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMS.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            FC_Supplier objSupplier = new FC_Supplier();
            return View(objSupplier);
        }
    }
}