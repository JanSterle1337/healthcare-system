using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Patient
    {

        [Key]
        public string Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime Birth {  get; set; }

        [Required]
        [StringLength(1)]
        public string Sex { get; set; }

        public int Age { get; set; }

        public ICollection<TermReservation> Terms { get; set; }
    }
}
