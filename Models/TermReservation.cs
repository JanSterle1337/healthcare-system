using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

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

        [DefaultValue("neizvedeno")]
        [Required]
        public string TermStatus { get; set; }
        
        [Required]
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ReservationId: " + ReservationId);
            sb.AppendLine("Date: "+ Date.ToString());
            sb.AppendLine("ReservedBy: " + ReservedBy);
            sb.AppendLine("CreatedAt: " + CreatedAt);
            sb.AppendLine("PatientId: " + PatientId);
            sb.AppendLine("DoctorId: " + DoctorId);
            sb.AppendLine("CreatedAt: " + CreatedAt);

            return sb.ToString();
        }
    }
}
