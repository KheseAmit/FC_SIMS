using System;
using System.Collections.Generic;
using FC.Entities;

namespace SIMS.Models
{
    public class PurchaseOrderModel
    {
        public PurchaseOrderModel()
        {
            PurchaseOrderProductModelList = new List<PurchaseOrderProductModel>();
            PurchaseOrderProductModel = new PurchaseOrderProductModel();
        }
        public int Id { get; set; }
        public string PONumber { get; set; }
        public int SupplierId { get; set; }
        public DateTime POdate { get; set; }
        public double POTotalAmount { get; set; }
        public double SalesTax { get; set; }
        public bool IsMailSent { get; set; }
        public string Comment { get; set; }
        public DateTime CancelDate { get; set; }
        public int CanceledBy { get; set; }
        public string ReasonforCancel { get; set; }

        public List<PurchaseOrderProductModel> PurchaseOrderProductModelList { get; set; }
        public PurchaseOrderProductModel PurchaseOrderProductModel { get; set; }
        public List<FC_PurchaseOrder> PurchaseOrderList { get; set; }
    }

    public class PurchaseOrderProductModel
    {
        public int PurchaseOrderProductId { get; set; }
        public FC_Product Product { get; set; }
        public int Quantity { get; set; }
        public double ProductTotalAmount { get; set; }
    }
}