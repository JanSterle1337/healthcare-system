using healthcare_system.Models;
using Microsoft.AspNetCore.Identity;

namespace healthcare_system.Data.Mock
{
    public class PatientMock
    {

        private readonly ApplicationDbContext _db;

        public PatientMock(ApplicationDbContext db)
        {
            _db = db;
        }

        /*public List<Patient> seedPatients()
        {

            var roles = new IdentityRole[]
{
                new IdentityRole{Id="1", Name="Doctor", NormalizedName="doctor"},
                new IdentityRole{Id="2", Name="Patient", NormalizedName="patient"}
};

            var mockPatients = new List<Patient>
            {
                    new Patient
                    {
                        Id = "1",
                        FirstName = "Jan",
                        LastName = "Sterle",
                        Email = "jan.sterle@gmail.com",
                        NormalizedEmail = "JAN.STERLE@GMAIL.COM",
                        UserName = "jan.sterle@gmail.com",
                        NormalizedUserName = "jan.sterle@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumberConfirmed = true,
                        Birth = new DateTime(1990, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                        Age = 32,
                        PhoneNumber = "051866321",
                        SecurityStamp = Guid.NewGuid().ToString("D"),                
                    },
                    new Patient
                    {
                        Id = "2",
                        FirstName = "Tim",
                        LastName = "Marinsek",
                        Email = "tim.marinsek@gmail.com",
                        NormalizedEmail = "TIM.MARINSEK@GMAIL.COM",
                        UserName = "tim.marinsek@gmail.com",
                        NormalizedUserName = "tim.marinsek@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumberConfirmed = true,
                        Birth = new DateTime(1995, 5, 12, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                        Age = 32,
                        PhoneNumber = "070755331",
                        SecurityStamp= Guid.NewGuid().ToString("D"),
                    },
                    new Patient
                    {
                        Id = "3",
                        FirstName = "Nejc",
                        LastName = "Narobe",
                        Email = "nejc.narobe@gmail.com",
                        NormalizedEmail = "NEJC.NAROBE@GMAIL.COM",
                        UserName = "nejc.narobe@gmail.com",
                        NormalizedUserName = "nejc.narobe@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumberConfirmed = true,
                        Birth = new DateTime(2003, 12, 12, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                     
                        Age = 32,
                        PhoneNumber = "123456789",
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                    },
                    new Patient
                    {
                        Id = "4",
                        FirstName = "Nejc",
                        LastName = "Sila",
                        Email = "nejc.sila@gmail.com",
                        NormalizedEmail = "NEJC.SILA@GMAIL.COM",
                        UserName = "nejc.sila@gmail.com",
                        NormalizedUserName = "nejc.sila@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumberConfirmed = true,
                        Birth = new DateTime(2005, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        Sex = "M",
                   
                        Age = 32,
                        PhoneNumber = "987654321",
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    }
            };

            List<Patient> patientsFromDb = _db.Patients.ToList();

            foreach (Patient patient in patientsFromDb)
            {
                _db.Remove(patient);
            }

            _db.SaveChanges();


            var existingPatientIds = _db.Patients.Select(p => p.Id).ToList();

            foreach (var mockPatient in mockPatients)
            {
                if (!existingPatientIds.Contains(mockPatient.Id))
                {
                    if (!_db.Patients.Any(d => d.UserName == mockPatient.UserName))
                    {
                        var password = new PasswordHasher<Patient>();
                        var hashed = password.HashPassword(mockPatient, "Test12345!");
                        mockPatient.PasswordHash = hashed;
                        mockPatient.Password = hashed;
                    }

                    _db.Patients.Add(mockPatient);

                    var UserRoles = new IdentityUserRole<string>[]
                    {
                        new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=mockPatient.Id}
                    };

                    foreach (IdentityUserRole<string> r in UserRoles)
                    {
                        _db.UserRoles.Add(r);
                    }
                }
            }

            _db.SaveChanges();
            return _db.Patients.ToList();

            /*foreach (var mockPatient in mockPatients)
            {
                if (!existingPatientIds.Contains(mockPatient.Id))
                {
                    _db.Patients.Add(mockPatient);
                }
            }

            _db.SaveChanges();
            return _db.Patients.ToList();  

        } */

    }
}
