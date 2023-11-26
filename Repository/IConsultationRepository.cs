using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IConsultationRepository
    {
        List<Consultation> GetAll();
        Consultation GetById(string id);
        void Add(Consultation consultation);
        void Update(Consultation consultation);
        void Remove(string id);
    }
}
