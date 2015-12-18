using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FC.Entities
{
    [Table("FC_Users")]
    public class FC_Users : DataAccessEntityBase
    {
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
 