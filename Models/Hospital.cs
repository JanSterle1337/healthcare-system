using System.ComponentModel.DataAnnotations;

namespace healthcare_system.Models
{
    public class Hospital
    {
        [Key]
        [StringLength(50)]
        public string HospitalId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
