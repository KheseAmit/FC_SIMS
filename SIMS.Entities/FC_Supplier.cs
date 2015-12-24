using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FC.Entities
{
    [Table("FC_Supplier")]
    public class FC_Supplier : DataAccessEntityBase
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactPerson1 { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactPerson2 { get; set; }
        public string ContactNumber2 { get; set; }
        public string BankName1 { get; set; }
        public string BankAccountNumber1 { get; set; }
        public string BankName2 { get; set; }
        public string BankAccountNumber2 { get; set; }
    }
}