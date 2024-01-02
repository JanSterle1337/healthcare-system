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
                        PatientId = "1",
                        DoctorId = "10",
                        TermStatus = "neizvedeno"

                    },
                    new TermReservation
                    {

                        ReservationId = "R2",
                        Date = new DateTime(2000, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                        ReservedBy  = true,
                        CreatedAt = new DateTime(2005, 1, 10, 0, 0, 0, DateTimeKind.Utc),
                        PatientId = "2",
                        DoctorId = "11",
                        TermStatus = "neizvedeno"

                    },

                    new TermReservation
                    {
                        ReservationId = "R3",
                        Date = new DateTime(2023, 12, 12, 0, 0, 0, DateTimeKind.Utc),
                        ReservedBy = true,
                        CreatedAt = DateTime.Now,
                        PatientId = "3",
                        DoctorId= "12",
                        TermStatus = "neizvedeno"

                    },
                    new TermReservation
                    {
                        ReservationId = "R4",
                        Date = new DateTime(2023, 12, 13, 0, 0, 0, DateTimeKind.Utc),
                        ReservedBy = true,
                        CreatedAt = DateTime.Now,
                        PatientId = "4",
                        DoctorId = "13",
                        TermStatus = "neizvedeno"

                    }

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
