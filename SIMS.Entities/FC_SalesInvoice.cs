using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Entities
{
    [Table("FC_SalesInvoice")]
    public class FC_SalesInvoice
    {
        public FC_SalesInvoice()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
            IsCanceled = false;
            CreatedBy = 1;
            IsMailSent = false;
        }


        [Key]
        public int Id { get; set; }

        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerId { get; set; }
        public double BillTotalAmount { get; set; }
        public int SalesTax { get; set; }
        public double SalesTaxAmount { get; set; }
        public int Vat { get; set; }
        public double VatAmount { get; set; }
        public double OtherAmount { get; set; }
        public bool IsMailSent { get; set; }
        public string Comment { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CancelDate { get; set; }
        public int CanceledBy { get; set; }
        public string ReasonforCancel { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}
