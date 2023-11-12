using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace healthcare_system.Models
{
    public class Patient
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string PatientId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public DateTime Birth {  get; set; }

        [Required]
        [StringLength(1)]
        public string Sex { get; set; }

        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<TermReservation> Terms { get; set; }
    }
}
