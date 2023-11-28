using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Doctor : ApplicationUser
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [ForeignKey("Department")]
        public string DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<TermReservation> Terms { get; set; }
    }
}
