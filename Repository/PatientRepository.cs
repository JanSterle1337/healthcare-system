using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Patient> GetAll()
        {
            return _db.Patients.ToList();
        }

        public Patient GetById(string id)
        {
            return _db.Patients.Find(id);
        }

        public void Add(Patient patient)
        {
            _db.Patients.Add(patient);
            _db.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _db.Patients.Update(patient);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var patient = _db.Patients.Find(id);

            if (patient != null)
            {
                _db.Patients.Remove(patient);
                _db.SaveChanges();
            }
        }
    }
}
