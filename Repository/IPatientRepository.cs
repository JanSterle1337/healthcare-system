using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
        Patient GetById(string id);
        //Patient GetPatientsByEmails(string email);
        void Add(Patient patient);
        void Update(Patient patient);
        void Remove(string id);
    }
}
