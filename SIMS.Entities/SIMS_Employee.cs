using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FC.Entities
{
    [Table("SIMS_Employee")]
    public class SIMS_Employee : DataAccessEntityBase
    {

        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public int EmployeeTypeId { get; set; }
        public string ContactNumber { get; set; }
        public bool EmailId { get; set; }
        public int CreatedBy { get; set; }

        
       // [DefaultValue(System.DateTime.Now.Date.ToString())]
        public DateTime CreatedOn { get; set; }


        public int? UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual FC_Users FC_Users_CreatedBy { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual FC_Users FC_Users_UpdatedBy { get; set; }

       
 

        [ForeignKey("DesignationId")]
        public virtual SIMS_Designation SIMS_Designation_SIMS_Employee { get; set; }

        [ForeignKey("EmployeeTypeId")]
        public virtual SIMS_EmployeeType SIMS_EmployeeType_SIMS_Employee { get; set; }
    }
}