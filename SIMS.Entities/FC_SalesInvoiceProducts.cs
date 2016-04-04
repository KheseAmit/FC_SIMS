using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FC.Entities;

namespace SIMS.Entities
{
    
    [Table("FC_SalesInvoiceProducts")]
    public class FC_SalesInvoiceProducts
    {
        [Key]
        public int SalseInvoiceProductId { get; set; }

        public int ProductId { get; set; }
        public int SalesInvoiceId { get; set; }
        public string Productdescription { get; set; }
        public int Quantity { get; set; }
        public double ProductTotalAmount { get; set; }
        [ForeignKey("SalesInvoiceId")]
        public virtual FC_SalesInvoice FC_FC_SalesInvoice_FC_SalesInvoiceProducts { get; set; }

        [ForeignKey("ProductId")]
        public virtual FC_Product FC_Product_FC_SalesInvoiceProducts { get; set; }

    
    
    }
}
