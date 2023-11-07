using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Department
    {
        [Key]
        [StringLength(50)]
        public string DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Floor { get; set; }

        [Required]
        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }

        public Hospital Hospital { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
