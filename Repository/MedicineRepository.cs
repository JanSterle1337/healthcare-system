using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext _db;

        public MedicineRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Medicine> GetAll()
        {
            return _db.Medicines.ToList();
        }

        public Medicine GetById(string id)
        {
            return _db.Medicines.Find(id);
        }

        public void Add(Medicine medicine)
        {
            _db.Medicines.Add(medicine);
            _db.SaveChanges();
        }

        public void Update(Medicine medicine)
        {
            _db.Medicines.Update(medicine);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var medicine = _db.Medicines.Find(id);

            if (medicine != null)
            {
                _db.Medicines.Remove(medicine);
                _db.SaveChanges();
            }
        }
    }
}
