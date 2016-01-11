using FC.Entities;
using FC.Repositories;
using SIMS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMS.Models;

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
         

            var varPo = new PurchaseOrderProductModel
            {
                Product = product,
                Quantity = quantity,
                ProductTotalAmount = product.PurchasePrice * quantity
            };
            if (Session != null && Session["purchaseOrderProducts"] != null)
            {
                purchaseOrderModel.PurchaseOrderProductModelList = (List<PurchaseOrderProductModel>)Session["purchaseOrderProducts"];
            }
            purchaseOrderModel.PurchaseOrderProductModelList.Add(varPo);

            if (Session != null) Session["purchaseOrderProducts"] = purchaseOrderModel.PurchaseOrderProductModelList;

            return PartialView("_PurchaseOrderProductsList", purchaseOrderModel);
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