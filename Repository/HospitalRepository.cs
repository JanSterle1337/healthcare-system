using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDbContext _db;

        public HospitalRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Hospital> GetAll()
        {
            return _db.Hospitals.ToList();
        }

        public Hospital GetById(string id)
        {
            return _db.Hospitals.Find(id);
        }

        public void Add(Hospital hospital)
        {
            _db.Hospitals.Add(hospital);
            _db.SaveChanges();
        }

        public void Update(Hospital hospital)
        {
            _db.Hospitals.Update(hospital);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var hospital = _db.Hospitals.Find(id);

            if (hospital != null)
            {
                _db.Hospitals.Remove(hospital);
                _db.SaveChanges();
            }
        }
    }
}
