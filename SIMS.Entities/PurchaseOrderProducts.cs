using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Entities
{
    [Table("FC_PurchaseOrderProducts")]
    public class FC_PurchaseOrderProducts
    {
        [Key]
        public int PurchaseOrderProductId { get; set; }

        public int ProductId { get; set; }
        public int PurchaseOrderId { get; set; }
        public string Productdescription { get; set; }
        public int Quantity { get; set; }
        public double ProductTotalAmount { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public virtual FC_PurchaseOrder FC_PurchaseOrder_FC_PurchaseOrderProducts { get; set; }

        [ForeignKey("ProductId")]
        public virtual FC_Product FC_Product_FC_PurchaseOrderProducts { get; set; }
    }
}
