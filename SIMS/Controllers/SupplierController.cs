using FC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FC.Repositories;
using SIMS.Models;
using System.IO;

namespace SIMS.Controllers
{
    [RouteArea("Supplier")]
    public class SupplierController : Controller
    {

        SupplierRepository SupplierDb = new SupplierRepository();
        // GET: Supplier
        public ActionResult Index()
        {
            FC_Supplier objSupplier = new FC_Supplier();
            SupplierViewModels viewmodel = new SupplierViewModels();
            IEnumerable<FC_Supplier> lstSupplier = SupplierDb.GetAll();
            viewmodel.supplierList = lstSupplier.ToList();
            ViewBag.SupplierList = viewmodel;
            return View(objSupplier);
        }

        [HttpPost]
        public ActionResult SaveSupplier(FC_Supplier model)
        {
            SupplierViewModels viewmodel = new SupplierViewModels();
            SupplierDb.Add(model);
            IEnumerable<FC_Supplier> lstSupplier = SupplierDb.GetAll();
           
            viewmodel.supplierList = lstSupplier.ToList();
            ViewBag.SupplierList = viewmodel;
            // return Json(lstSupplier.ToList(), JsonRequestBehavior.AllowGet);
          //  var modelhtml = RenderRazorViewToString("_SupplierList", viewmodel);
            //return Json(new
            //{
            //    Success = true,
            //    PartialViewHtml = modelhtml
            //});
            return PartialView("_SupplierList", viewmodel);
            //   return PartialView(lstSupplier);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}