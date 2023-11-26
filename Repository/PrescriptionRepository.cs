using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class PrescriptionRepository
    {
        private readonly ApplicationDbContext _db;

        public PrescriptionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Prescription> GetAll()
        {
            return _db.Prescriptions.ToList();
        }

        public Prescription GetById(string id)
        {
            return _db.Prescriptions.Find(id);
        }

        public void Add(Prescription prescription)
        {
            _db.Prescriptions.Add(prescription);
            _db.SaveChanges();
        }

        public void Update(Prescription prescription)
        {
            _db.Prescriptions.Update(prescription);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var prescription = _db.Prescriptions.Find(id);

            if (prescription != null)
            {
                _db.Prescriptions.Remove(prescription);
                _db.SaveChanges();
            }
        }
    }
}
