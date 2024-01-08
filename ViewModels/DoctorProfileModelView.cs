using healthcare_system.Models;

namespace healthcare_system.ViewModels
{
    public class DoctorProfileModelView
    {
        public ApplicationUser doctorAccount { get; set; }
        public Doctor doctor {  get; set; }
        public List<TermReservation> doctorTerms { get; set; }
        public Hospital hospital { get; set; }
        public Department department { get; set; }
    }
}
