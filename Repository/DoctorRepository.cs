using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _db;

        public DoctorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Doctor> GetAll()
        {
            return _db.Doctors.ToList();
        }

        public Doctor GetById(string id)
        {
            return _db.Doctors.Find(id);
        }

        public void Add(Doctor doctor)
        {
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _db.Doctors.Update(doctor);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var doctor = _db.Doctors.Find(id);

            if (doctor != null)
            {
                _db.Doctors.Remove(doctor);
                _db.SaveChanges();
            }
        }
    }
}
