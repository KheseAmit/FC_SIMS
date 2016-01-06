using FC.Entities;
using FC.Repositories;
using SIMS.Helper;
using SIMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMS.Controllers
{
    [FcAuthorize]
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {

        readonly ProductRepository _productDb = new ProductRepository();
        readonly SupplierRepository _supplierDb = new SupplierRepository();
        readonly ProductTypeRepository _ProductTypeDb = new ProductTypeRepository();
        readonly ManufactureRepository _ManufactureDb = new ManufactureRepository();
        #region Action
        // GET: Product

        [Route("{supplierId}", Name = "Index")]
        public ActionResult Index(int supplierId = 0)
        {
            var objProduct = new FC_Product();

            if (supplierId != 0)
                objProduct.SupplierId = supplierId;

            GetProductListModel();
            return View(objProduct);
        }

        [HttpPost]
        [Route("SaveProduct")]
        public ActionResult SaveProduct(FC_Product model)
        {
            _productDb.SaveChanges(model);
            return PartialView("_ProductList", GetProductListModel());
        }

        [HttpGet]
        [Route("EditProduct")]
        public ActionResult EditProduct(int productId)
        {
            var Product = _productDb.Get(productId);
            GetProductListModel();
            return PartialView("_ProductForm", Product);
        }

        [HttpGet]
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct(int productId)
        {
            var product = _productDb.Get(productId);
            product.IsDeleted = true;
            _productDb.SaveChanges(product);
            return PartialView("_ProductList", GetProductListModel());
        }

        #endregion

        #region Methods

        public ProductViewModels GetProductListModel()
        {
            var lstProduct = _productDb.GetAll();
            var lstSupplier = _supplierDb.GetAll();
            var lstProducttype = _ProductTypeDb.GetAll();
            var lstManufacture = _ManufactureDb.GetAll();
            var viewmodel = new ProductViewModels {productList = lstProduct.ToList()};

            ViewBag.ProductList = viewmodel;
            ViewBag.SupplierList = lstSupplier;
            ViewBag.ProducttypeList = lstProducttype;
            ViewBag.ManufactureList = lstManufacture;
 

            return viewmodel;
        }

        #endregion
    }
}