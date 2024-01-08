using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface ITermReservationRepository
    {
        List<TermReservation> GetAll();
        List<TermReservation> GetPastTermsForPatient(string patientId);
        List<TermReservation> GetFutureTermsForPatient(string patientId);
        TermReservation GetById(string id);
        void Add(TermReservation term);
        void Update(TermReservation term);
        void Remove(string id);

    }
}
