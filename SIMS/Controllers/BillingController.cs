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
        readonly PORepository _PORepository = new PORepository();
        readonly POproductRepository _POproductRepository = new POproductRepository();
        #region Action
        // GET: Product


        public ActionResult PurchaseOrder()
        {
            var purchaseOrderModel = new PurchaseOrderModel();
            Session["purchaseOrderProducts"] = null;
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

        [HttpPost]
        [Route("SavePurchaseOrder")]
        public ActionResult SavePurchaseOrder(PurchaseOrderModel model)
        {
            model.PurchaseOrderProductModelList =
                 (List<PurchaseOrderProductModel>)Session["purchaseOrderProducts"];

            FC_PurchaseOrder newOrder = new FC_PurchaseOrder();
            newOrder.POTotalAmount = model.POTotalAmount;
            newOrder.SupplierId = model.SupplierId;
            newOrder.SalesTax = model.SalesTax;
            newOrder.OtherAmount = model.OtherAmount;
            newOrder.Comment = model.Comment;
            newOrder.PONumber = "PO" + model.SupplierId;
            newOrder.POdate = System.DateTime.Now;
            _PORepository.SaveChanges(newOrder);

          
            FC_PurchaseOrderProducts orderproducts = new FC_PurchaseOrderProducts();
            foreach (var poproduct in model.PurchaseOrderProductModelList)
            {
                orderproducts.ProductId = poproduct.PurchaseOrderProductId;
                orderproducts.ProductTotalAmount = poproduct.ProductTotalAmount;
                orderproducts.Quantity = poproduct.Quantity;
                orderproducts.PurchaseOrderId = newOrder.Id;
                _POproductRepository.SaveChanges(orderproducts);
            }


            var purchaseOrderModel = new PurchaseOrderModel();
            Session["purchaseOrderProducts"] = null;
            GetProductListModel();
            return PartialView("_PurchaseOrderProductsList", purchaseOrderModel);
        }

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
            var poList = _PORepository.GetAll();
            var viewmodel = new PurchaseOrderModel { PurchaseOrderList = poList.ToList() };

            ViewBag.ProductList = lstProduct;
            ViewBag.SupplierList = lstSupplier;
            ViewBag.PurchaseOrderList = viewmodel;
            return null;
        }

        #endregion
    }
}