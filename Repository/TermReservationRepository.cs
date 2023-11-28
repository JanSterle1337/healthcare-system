using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class TermReservationRepository : ITermReservationRepository
    {
        private readonly ApplicationDbContext _db;

        public TermReservationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<TermReservation> GetAll()
        {
            return _db.TermReservations.ToList();
        }

        public TermReservation GetById(string id)
        {
            return _db.TermReservations.Find(id);
        }

        public void Add(TermReservation term)
        {
            _db.TermReservations.Add(term);
            _db.SaveChanges();
        }

        public void Update(TermReservation term)
        {
            _db.TermReservations.Update(term);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var term = _db.TermReservations.Find(id);

            if (term != null)
            {
                _db.TermReservations.Remove(term);
                _db.SaveChanges();
            }
        }

    }
}
