using healthcare_system.Models;

namespace healthcare_system.ViewModels
{
    public class EditTermReservationViewModel
    {
        public string ReservationId { get; set; }
        public DateTime Date { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
    }
}
