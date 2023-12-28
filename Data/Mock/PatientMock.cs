using healthcare_system.Models;

namespace healthcare_system.Data.Mock
{
    public class PatientMock
    {

        private readonly ApplicationDbContext _db;

        public PatientMock(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Patient> seedPatients()
        {
            var mockPatients = new List<Patient>
            {
                    new Patient
                    {
                        PatientId = "P3",
                        FirstName = "Jan",
                        LastName = "Sterle",
                        Birth = new DateTime(1990, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                        Password = "Jancigan",
                        Age = 32,
                        EmailAddress = "jan.sterle@gmail.com",
                        PhoneNumber = "123-456-7890"
                    },
                    new Patient
                    {
                        PatientId = "P4",
                        FirstName = "Tim",
                        LastName = "Marinsek",
                        Birth = new DateTime(1995, 5, 12, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                        Password = "Timcigan",
                        Age = 32,
                        EmailAddress = "tim.marinsek@gmail.com",
                        PhoneNumber = "123-456-7890"
                    },
                    new Patient
                    {
                        PatientId = "P5",
                        FirstName = "Nejc",
                        LastName = "Narobe",
                        Birth = new DateTime(2003, 12, 12, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                        Password = "Nejccigan",
                        Age = 32,
                        EmailAddress = "nejc.narobe@gmail.com",
                        PhoneNumber = "123-456-7890"
                    },
                    new Patient
                    {
                        PatientId = "P6",
                        FirstName = "Nejc",
                        LastName = "Sila",
                        Birth = new DateTime(2005, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                        Password = "Nejccigan123",
                        Age = 32,
                        EmailAddress = "nejc.sila@gmail.com",
                        PhoneNumber = "123-456-7890"
                    }
            };

            var existingPatientIds = _db.Patients.Select(p => p.PatientId).ToList();

            foreach (var mockPatient in mockPatients)
            {
                if (!existingPatientIds.Contains(mockPatient.PatientId))
                {
                    _db.Patients.Add(mockPatient);
                }
            }

            _db.SaveChanges();
            return _db.Patients.ToList();

        }

    }
}
