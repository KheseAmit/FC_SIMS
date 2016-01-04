using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FC.Entities
{
    [Table("FC_Product")]
    public class FC_Product : DataAccessEntityBase
    {
        public string ProductCode { get; set; }
        public int ProductTypeId { get; set; }
        public string RetailPrice { get; set; }
        public double WholeSalePrice { get; set; }
        public double PurchasePrice { get; set; }
        public double Weight { get; set; }
        public int SupplierId { get; set; }
        public int ManufactureId { get; set; }

    }
}
