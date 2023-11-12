using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace healthcare_system.Models
{
    public class Medicine
    {
        [Key]
        public string MedicineId { get; set; }
        [Required]
        public string MedicineName { get; set; }

        [Required]
        public string Category { get; set; }

        public string Description { get; set; }

        public ICollection<Prescription> Prescription { get; set; }
        


    }
}
