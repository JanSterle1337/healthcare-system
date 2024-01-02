using Microsoft.AspNetCore.Identity;

namespace healthcare_system.Data.Mock
{
    public class MockRemover
    {

        private readonly ApplicationDbContext _context;

        public MockRemover(ApplicationDbContext _db) 
        {
            _context = _db;
        }

        public void removePreviousMockData()
        {
            var prescriptions = _context.Prescriptions.ToList();
            foreach (var prescription in prescriptions)
            {
                _context.Prescriptions.Remove(prescription);
            }
            _context.SaveChanges();

            var medicinePrescriptions = _context.Medicines.ToList();

            foreach (var medicine in medicinePrescriptions)
            {
                _context.Medicines.Remove(medicine);
            }
            _context.SaveChanges();

            var consultations = _context.Consultations.ToList();

            foreach (var consultation in consultations)
            {
                _context.Consultations.Remove(consultation);
            }
            _context.SaveChanges();

            var termReservations = _context.TermReservations.ToList();

            foreach ( var termReservation in termReservations)
            {
                _context.TermReservations.Remove(termReservation);
            }
            _context.SaveChanges();

            var userClaims = _context.UserClaims.ToList();

            foreach (var userClaim in userClaims)
            {
                _context.UserClaims.Remove(userClaim);   
            }
            _context.SaveChanges();

            var userLogins = _context.UserLogins.ToList();

            foreach (var userLogin in userLogins)
            {
                _context.UserLogins.Remove(userLogin);
            }
            _context.SaveChanges();

            var userTokens = _context.UserTokens.ToList();
            foreach (var userToken in userTokens)
            {
                _context.UserTokens.Remove(userToken);
            }
            _context.SaveChanges();

            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                _context.Users.Remove(user);
            }

            var departments = _context.Departments.ToList();
            foreach (var department in departments)
            {
                _context.Departments.Remove(department);
            }

            var hospitals = _context.Hospitals.ToList();
            foreach (var hospital in hospitals)
            {
                _context.Hospitals.Remove(hospital);
            }
        }

    }
}
