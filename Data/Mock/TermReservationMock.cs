using healthcare_system.Models;

namespace healthcare_system.Data.Mock
{
    public class TermReservationMock
    {

        private readonly ApplicationDbContext _db;

        public TermReservationMock(ApplicationDbContext db)
        {
            _db = db;
        }

        public void seedTermReservations(List<Patient> patients)
        {
            var mockReservations = new List<TermReservation>
            {
                    new TermReservation
                    {

                        ReservationId = "R1",
                        Date = new DateTime(1990, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                        ReservedBy  = true,
                        CreatedAt = new DateTime(1990, 1, 10, 0, 0, 0, DateTimeKind.Utc),
                        PatientId = "P3",
                        DoctorId = "D1",
                        Patient = patients[0]
                        
                    },
                    new TermReservation
                    {

                        ReservationId = "R2",
                        Date = new DateTime(2000, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                        ReservedBy  = true,
                        CreatedAt = new DateTime(2005, 1, 10, 0, 0, 0, DateTimeKind.Utc),
                        PatientId = "P4",
                        DoctorId = "D2",
                        Patient = patients[1]

                    },

            };

            var existingPatientIds = _db.TermReservations.Select(p => p.ReservationId).ToList();

            foreach (var mockReservation in mockReservations)
            {
                if (!existingPatientIds.Contains(mockReservation.ReservationId))
                {
                    _db.TermReservations.Add(mockReservation);
                }
            }

            _db.SaveChanges();
        }

    }
}
