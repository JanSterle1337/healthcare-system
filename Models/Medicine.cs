using System.ComponentModel.DataAnnotations;

namespace healthcare_system.Models
{
    public class Medicine
    {
        [Key]
        public string MedicineId { get; set; }
        [Required]
        public string MedicineName { get; set; }

        public ICollection<Prescription> Prescription { get; set; }
        


    }
}
