using System.Web.Hosting;
using FC.Entities;
using FC.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using SIMS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMS.Models;
using System.IO;
using iTextSharp.text.html.simpleparser;

namespace SIMS.Controllers
{
    [FcAuthorize]
    [RoutePrefix("Billing")]
    public class BillingController : Controller
    {
 
        readonly ProductRepository _productDb = new ProductRepository();
        readonly SupplierRepository _supplierDb = new SupplierRepository();
        readonly ProductTypeRepository _ProductTypeDb = new ProductTypeRepository();
        readonly ManufactureRepository _ManufactureDb = new ManufactureRepository();
        #region Action
        // GET: Product

         
        public ActionResult PurchaseOrder()
        {
            var purchaseOrderModel = new PurchaseOrderModel();
           GetProductListModel();
           return View(purchaseOrderModel);
        }

        [HttpGet]
        public ActionResult AddProductInorder(int productId, int quantity)
        {
            var product = _productDb.Get(productId);
            var purchaseOrderModel = new PurchaseOrderModel();

            if (Session != null && Session["purchaseOrderProducts"] != null)
            {
                purchaseOrderModel.PurchaseOrderProductModelList = (List<PurchaseOrderProductModel>)Session["purchaseOrderProducts"];
            }
            var purchaseOrderProductIdIndex = 0;
            if (purchaseOrderModel.PurchaseOrderProductModelList.Count > 0)
            {
                purchaseOrderProductIdIndex = purchaseOrderModel.PurchaseOrderProductModelList.Last().PurchaseOrderProductId;
            }

            var varPo = new PurchaseOrderProductModel
            {
                PurchaseOrderProductId = purchaseOrderProductIdIndex + 1,
                Product = product,
                Quantity = quantity,
                ProductTotalAmount = product.PurchasePrice * quantity
            };
            purchaseOrderModel.PurchaseOrderProductModelList.Add(varPo);
            CalculatePoAmount(purchaseOrderModel.PurchaseOrderProductModelList);
            if (Session != null) Session["purchaseOrderProducts"] = purchaseOrderModel.PurchaseOrderProductModelList;

            return PartialView("_PurchaseOrderProductsList", purchaseOrderModel);
        }

        [HttpGet]
        public ActionResult RemoveProductInorder(int PurchaseOrderProductId)
        {
            var purchaseOrderModel = new PurchaseOrderModel();
            if (Session != null && Session["purchaseOrderProducts"] != null)
            {
                purchaseOrderModel.PurchaseOrderProductModelList = (List<PurchaseOrderProductModel>)Session["purchaseOrderProducts"];
            }
            if (purchaseOrderModel.PurchaseOrderProductModelList != null)
            {
                var varPo = purchaseOrderModel.PurchaseOrderProductModelList.FirstOrDefault(c => c.PurchaseOrderProductId == PurchaseOrderProductId);
                purchaseOrderModel.PurchaseOrderProductModelList.Remove(varPo);
                CalculatePoAmount(purchaseOrderModel.PurchaseOrderProductModelList);
                if (Session != null) Session["purchaseOrderProducts"] = purchaseOrderModel.PurchaseOrderProductModelList;
            }

            return PartialView("_PurchaseOrderProductsList", purchaseOrderModel);
        }

        public void CalculatePoAmount(List<PurchaseOrderProductModel> purchaseOrderProductModelList)
        {
            var sumamount = purchaseOrderProductModelList.Sum(c => c.ProductTotalAmount);
            ViewBag.POTotalAmount = sumamount;
        }

        public FileResult MyActionOnController()
        {
            var purchaseOrderModel = new PurchaseOrderModel();
            if (Session != null && Session["purchaseOrderProducts"] != null)
            {
                purchaseOrderModel.PurchaseOrderProductModelList =
                    (List<PurchaseOrderProductModel>) Session["purchaseOrderProducts"];
            }
            var htmlContent = RenderRazorViewToString("POTemplate", purchaseOrderModel);
            return File(Help.ConvertHtmlToPdf(htmlContent).ToArray(), "application/pdf", "test.pdf");
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
 
        //[HttpPost]
        //[Route("SaveProduct")]
        //public ActionResult SaveProduct(FC_PurchaseOrder model)
        //{
        //    _productDb.SaveChanges(model);
        //    return PartialView("_ProductList", GetProductListModel());
        //}

        //[HttpGet]
        //[Route("EditProduct")]
        //public ActionResult EditProduct(int productId)
        //{
        //    var Product = _productDb.Get(productId);
        //    GetProductListModel();
        //    return PartialView("_ProductForm", Product);
        //}

        //[HttpGet]
        //[Route("DeleteProduct")]
        //public ActionResult DeleteProduct(int productId)
        //{
        //    var product = _productDb.Get(productId);
        //    product.IsDeleted = true;
        //    _productDb.SaveChanges(product);
        //    return PartialView("_ProductList", GetProductListModel());
        //}

        #endregion

        #region Methods

        public PurchaseOrderModel GetProductListModel()
        {
            var lstProduct = _productDb.GetAll();
            var lstSupplier = _supplierDb.GetAll();
            
        //    var viewmodel = new PurchaseOrderModel { PurchaseOrderList = lstProduct.ToList() };

            ViewBag.ProductList = lstProduct;
            ViewBag.SupplierList = lstSupplier;

            return null;
        }

        #endregion
    }
}