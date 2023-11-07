using System.ComponentModel.DataAnnotations;

namespace healthcare_system.Models
{
    public class Prescription
    {
        [Key]
        public string PrescriptionId { get; set; }
        public string Description { get; set; }
        public string ConsultationId { get; set; }
        public Consultation Consultation { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}
