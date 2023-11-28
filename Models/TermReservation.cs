using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthcare_system.Models
{
    public class TermReservation
    {
        [Key]
        [StringLength(50)]
        public string ReservationId { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }

        [Required]
        public bool ReservedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        [ForeignKey("Patient")]
        public string PatientId { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor{ get; set; }

        public TermReservation termReservation { get; set; }
    }
}
