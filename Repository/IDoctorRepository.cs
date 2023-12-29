using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
        Doctor GetById(string id);
        Doctor GetDoctorByEmail(string email);
        void Add(Doctor doctor);
        void Update(Doctor doctor);
        void Remove(string id);
    }
}
