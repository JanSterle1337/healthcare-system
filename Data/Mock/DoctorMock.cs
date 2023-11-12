using healthcare_system.Models;

namespace healthcare_system.Data.Mock
{
    public class DoctorMock
    {

        private readonly ApplicationDbContext _db;

        public DoctorMock(ApplicationDbContext db)
        {
            _db = db;
        }

        public void seedDoctors()
        {
            var mockDoctors = new List<Doctor>
            {
                new Doctor
                {
                    DoctorId = "D1",
                    FirstName = "Željko",
                    LastName = "Pikolovski",
                    Password = "hiska12345",
                    Email = "zeljko.pikolovski@gmail.com",
                    PhoneNumber = "070755355",
                    Specialization = "Gastroentrologija",
                    DepartmentId = "A3"
                },
                new Doctor
                {
                    DoctorId = "D2",
                    FirstName = "Peter",
                    LastName = "Novak",
                    Password = "cigancek123",
                    Email = "peter.novak@gmail.com",
                    PhoneNumber = "070755366",
                    Specialization = "Hematologija",
                    DepartmentId = "B1"
                },
                new Doctor
                {
                    DoctorId = "D3",
                    FirstName = "Sandra",
                    LastName = "Đukić",
                    Password = "bosnaJeZakon123",
                    Email = "sandra.đuric@gmail.com",
                    PhoneNumber = "031308601",
                    Specialization = "Hematologija",
                    DepartmentId = "B1"
                },
                new Doctor
                {
                    DoctorId = "D4",
                    FirstName = "Aleksandra",
                    LastName = "Dubrovnik",
                    Password = "morje12345",
                    Email = "aleksandra.dubrovnik@gmail.com",
                    PhoneNumber = "031308602",
                    Specialization = "Hipertenzija",
                    DepartmentId = "B2"
                },
                new Doctor
                {
                    DoctorId = "D5",
                    FirstName = "Joško",
                    LastName = "Debel",
                    Password = "debeliJosko12345",
                    Email = "josko.debel@gmail.com",
                    PhoneNumber = "031308600",
                    Specialization = "Hipertenzija",
                    DepartmentId = "B2"
                },
            };

            var existingDoctorIds = _db.Doctors.Select(d => d.DoctorId).ToList();

            foreach (var mockDoctor in mockDoctors)
            {
                if (!existingDoctorIds.Contains(mockDoctor.DoctorId))
                {
                    _db.Doctors.Add(mockDoctor);
                }
            }

            _db.SaveChanges();

        }
    }
}
