using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IHospitalRepository
    {
        List<Hospital> GetAll();
        Hospital GetById(string id);
        void Add(Hospital hospital);
        void Update(Hospital hospital);
        void Remove(string id);
    }
}
