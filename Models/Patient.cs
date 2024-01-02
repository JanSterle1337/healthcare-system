using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Patient : ApplicationUser
    {

        [Required]
        public DateTime Birth {  get; set; }

        [Required]
        [StringLength(1)]
        public string Sex { get; set; }

        public int Age { get; set; }

        public ICollection<TermReservation> Terms { get; set; }
    }
}
