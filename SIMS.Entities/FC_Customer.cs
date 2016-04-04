using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FC.Entities;

namespace SIMS.Entities
{
    [Table("FC_Customer")]
    public class FC_Customer : DataAccessEntityBase
    {
        public string Address { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string Email { get; set; }
    }
}
