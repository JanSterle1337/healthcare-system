using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Consultation
    {
        [Key]
        public string ConsultationId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("TermReservation")]
        public string ReservationId { get; set; }

        public TermReservation TermReservation { get; set; }
        public Prescription Prescription { get; set; }

    }
}
