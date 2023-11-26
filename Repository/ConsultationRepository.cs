using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ApplicationDbContext _db;

        public ConsultationRepository(ApplicationDbContext db) 
        {
            _db = db;
        }

        public List<Consultation> GetAll()
        {
            return _db.Consultations.ToList();
        }

        public Consultation GetById(string id) 
        {
            return _db.Consultations.Find(id);
        }

        public void Add(Consultation consultation)
        {
            _db.Consultations.Add(consultation);
            _db.SaveChanges();
        }

        public void Update(Consultation consultation)
        {
            _db.Consultations.Update(consultation);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var consultation = _db.Consultations.Find(id);

            if (consultation != null)
            {
                _db.Consultations.Remove(consultation);
                _db.SaveChanges();
            }
        }
    }
}
