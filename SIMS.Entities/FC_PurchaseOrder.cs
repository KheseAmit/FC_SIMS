using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Entities
{
    [Table("FC_PurchaseOrder")]
    public class FC_PurchaseOrder 
    {
        public FC_PurchaseOrder()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
            IsCanceled = false;
            CreatedBy = 1;
            IsMailSent = false;
        }


        [Key]
        public int Id { get; set; }
        public string PONumber { get; set; }
        public int SupplierId { get; set; }
        public DateTime POdate { get; set; }
        public double POTotalAmount { get; set; }
        public double SalesTax { get; set; }
        public double OtherAmount { get; set; }
        public bool IsMailSent { get; set; }
        public string Comment { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime? CancelDate { get; set; }
        public int? CanceledBy { get; set; }
        public string ReasonforCancel { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}
