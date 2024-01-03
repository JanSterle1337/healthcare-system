using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Doctor
    {

        [Key]
        public string Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [ForeignKey("Department")]
        public string DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<TermReservation> Terms { get; set; }
    }
}
