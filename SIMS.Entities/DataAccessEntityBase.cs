using System;
using System.ComponentModel.DataAnnotations;

namespace FC.Entities
{
    public abstract class DataAccessEntityBase
    {
        public DataAccessEntityBase()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
            IsDeleted = false;
            CreatedBy = 1;
        }

        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}