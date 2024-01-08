using healthcare_system.Models;

namespace healthcare_system.ViewModels
{
    public class PatientProfileModelView
    {
        public ApplicationUser patientAccount { get; set; }
        public Patient patient { get; set; }
        public List<TermReservation> pastTerms { get; set; }
        public List<TermReservation> futureTerms { get; set; }
    }
}
