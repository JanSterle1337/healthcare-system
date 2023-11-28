using healthcare_system.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.Numerics;

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

            var roles = new IdentityRole[]
{
                new IdentityRole{Id="1", Name="Doctor", NormalizedName="doctor"},
                new IdentityRole{Id="2", Name="Patient", NormalizedName="patient"}
};

            var rolesFromdb = _db.Roles.ToList();


            //always remove roles and add them back to db
            foreach (var role in rolesFromdb)
            {
                _db.Roles.Remove(role);
            }

            _db.SaveChanges();

            foreach (IdentityRole r in roles)
            {
                _db.Roles.Add(r);
            }
            _db.SaveChanges();

            var mockDoctors = new List<Doctor>
            {
            new Doctor
            {
                Id = "1",
                FirstName = "Željko",
                LastName = "Pikolovski",
                Email = "zeljko.pikolovski@gmail.com",
                NormalizedEmail = "ZELJKO.PIKOLOVSKI@GMAIL.COM",
                UserName = "zeljko.pikolovski@gmail.com",
                NormalizedUserName = "zeljko.pikolovski@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                PhoneNumber = "070755355",
                Specialization = "Gastroentrologija",
                DepartmentId = "A3",
                SecurityStamp = Guid.NewGuid().ToString("D")
            },
            new Doctor
            {
                Id = "2",
                FirstName = "Peter",
                LastName = "Novak",
                Email = "peter.novak@gmail.com",
                NormalizedEmail = "PETER.NOVAK@GMAIL.COM",
                UserName = "peter.novak@gmail.com",
                NormalizedUserName = "peter.novak@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                PhoneNumber = "070755366",
                Specialization = "Hematologija",
                DepartmentId = "B1",
                SecurityStamp = Guid.NewGuid().ToString("D")
            },
            new Doctor
            {
                Id = "3",
                FirstName = "Sandra",
                LastName = "Đukić",
                Email = "sandra.đuric@gmail.com",
                NormalizedEmail = "SANDRA.ĐURIC@GMAIL.COM",
                UserName = "sandra.đuric@gmail.com",
                NormalizedUserName = "sandra.đuric@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                PhoneNumber = "031308601",
                Specialization = "Hematologija",
                DepartmentId = "B1",
                SecurityStamp = Guid.NewGuid().ToString("D")
            },
            new Doctor
            {
                Id = "4",
                FirstName = "Aleksandra",
                LastName = "Dubrovnik",
                Password = "morje12345",
                Email = "aleksandra.dubrovnik@gmail.com",
                NormalizedEmail = "ALESANDRA.DUBROVNIK@GMAIL.COM",
                UserName = "aleksandra.dubrovnik@gmail.com",
                NormalizedUserName = "aleksandra.dubrovnik@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                PhoneNumber = "031308602",
                Specialization = "Hipertenzija",
                DepartmentId = "B2",
                SecurityStamp = Guid.NewGuid().ToString("D")
            },
            new Doctor
            {
                Id = "5",
                FirstName = "Joško",
                LastName = "Debel",
                Password = "debeliJosko12345",
                Email = "josko.debel@gmail.com",
                NormalizedEmail = "JOSKO.DEBEL@GMAIL.COM",
                UserName = "josko.debel@gmail.com",
                NormalizedUserName = "josko.debel@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                PhoneNumber = "031308600",
                Specialization = "Hipertenzija",
                DepartmentId = "B2",
                SecurityStamp = Guid.NewGuid().ToString("D")
            }
        };


            List<Doctor> doctorsFromDb = _db.Doctors.ToList();

            foreach (Doctor doc in doctorsFromDb)
            {
                _db.Remove(doc);
            }

            _db.SaveChanges();


            var existingDoctorIds = _db.Doctors.Select(d => d.Id).ToList();

            foreach (var mockDoctor in mockDoctors)
            {
               
                if (!existingDoctorIds.Contains(mockDoctor.Id))
                {

                    if (!_db.Doctors.Any(d => d.UserName == mockDoctor.UserName))
                    {
                        var password = new PasswordHasher<Doctor>();
                        var hashed = password.HashPassword(mockDoctor, "Test12345!");
                        mockDoctor.PasswordHash = hashed;
                        mockDoctor.Password = hashed;
                    }


                    _db.Doctors.Add(mockDoctor);

                    var UserRoles = new IdentityUserRole<string>[]
                    {
                    new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=mockDoctor.Id}
};

                    foreach (IdentityUserRole<string> r in UserRoles)
                    {
                        _db.UserRoles.Add(r);
                    }
                }
            }

            _db.SaveChanges();

        }
    }
}
