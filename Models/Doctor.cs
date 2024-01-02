using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Doctor : ApplicationUser
    {

        [Required]
        public string Specialization { get; set; }

        [Required]
        [ForeignKey("Department")]
        public string DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<TermReservation> Terms { get; set; }
    }
}
