using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetAll();
        Prescription GetById(string id);
        void Add(Prescription prescription);
        void Update(Prescription prescription);
        void Remove(string id);
    }
}
