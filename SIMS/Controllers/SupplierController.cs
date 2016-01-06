using FC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FC.Repositories;
using Microsoft.Ajax.Utilities;
using SIMS.Models;
using System.IO;
using SIMS.Helper;

namespace SIMS.Controllers
{
    [FcAuthorize]
    [RouteArea("Supplier")]
    public class SupplierController : Controller
    {
        readonly SupplierRepository _supplierDb = new SupplierRepository();

        #region Action
        // GET: Supplier
        public ActionResult Index()
        {
            var objSupplier = new FC_Supplier();
            GetSupplierListModel();
            return View(objSupplier);
        }

        [HttpPost]
        public ActionResult SaveSupplier(FC_Supplier model)
        {
            _supplierDb.SaveChanges(model);
            return PartialView("_SupplierList", GetSupplierListModel());
        }

        [HttpGet]
        public ActionResult EditSupplier(int supplierId)
        {
            var supplier = _supplierDb.Get(supplierId);
            return PartialView("_SupplierForm", supplier);
        }

        [HttpGet]
        public ActionResult DeleteSupplier(int supplierId)
        {
            var supplier = _supplierDb.Get(supplierId);
            supplier.IsDeleted = true;
            _supplierDb.SaveChanges(supplier);
            return PartialView("_SupplierList", GetSupplierListModel());
        }

        #endregion

        #region Methods
        public SupplierViewModels GetSupplierListModel()
        {
            var lstSupplier = _supplierDb.GetAll();
            var viewmodel = new SupplierViewModels {supplierList = lstSupplier.ToList()};
            ViewBag.SupplierList = viewmodel;
            return viewmodel;
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
        #endregion
    }
}