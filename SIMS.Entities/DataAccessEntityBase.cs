using System.ComponentModel.DataAnnotations;

namespace FC.Entities
{
    abstract public class DataAccessEntityBase
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}