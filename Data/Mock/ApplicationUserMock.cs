using healthcare_system.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Xml;

namespace healthcare_system.Data.Mock
{
    public class ApplicationUserMock
    {
        private readonly ApplicationDbContext _context;


        public ApplicationUserMock(ApplicationDbContext db)
        {
            _context = db;
        }

        public void seedApplicationUsers()
        {

            var roles = new IdentityRole[]
{
                new IdentityRole{Id="1", Name="Doctor", NormalizedName="doctor"},
                new IdentityRole{Id="2", Name="Patient", NormalizedName="patient"}
};

            var rolesFromdb = _context.Roles.ToList();

            foreach (var role in rolesFromdb)
            {
                _context.Roles.Remove(role);
            }

            _context.SaveChanges();


            foreach (IdentityRole r in roles)
            {
                _context.Roles.Add(r);
            }
            _context.SaveChanges();


            var mockApplicationUsersDoctors = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id="1",
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
                    Discriminator = "Doctor",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new ApplicationUser
                {
                    Id="2",
                    FirstName = "Peter",
                    LastName = "Novak",
                    Email = "peter.novak@gmail.com",
                    NormalizedEmail = "PETER.NOVAK@GMAIL.COM",
                    UserName = "peter.novak@gmail.com",
                    NormalizedUserName = "peter.novak@gmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    Discriminator = "Doctor",
                    PhoneNumber = "070755355",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new ApplicationUser
                {
                    Id="3",
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
                    Discriminator = "Doctor",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new ApplicationUser
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
                    Discriminator = "Doctor",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new ApplicationUser
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
                Discriminator = "Doctor",
                SecurityStamp = Guid.NewGuid().ToString("D")
                }
            };

            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Id = "1",
                    ApplicationUserId = "1",
                    Specialization = "Gastroentrologija",
                    DepartmentId = "A3",
                },
                new Doctor
                {
                    Id = "2",
                    ApplicationUserId = "2",
                    Specialization = "Hematologija",
                    DepartmentId = "B1"
                },
                new Doctor
                {
                    Id = "3",
                    ApplicationUserId = "3",
                    Specialization = "Hematologija",
                    DepartmentId = "B1"
                },
                new Doctor
                {
                    Id="4",
                    ApplicationUserId = "4",
                    Specialization = "Hipertenzija",
                    DepartmentId = "B2"
                }
                

            };


            var mockApplicationUsersPatients = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                        Id = "6",
                        FirstName = "Jan",
                        LastName = "Sterle",
                        Email = "jan.sterle@gmail.com",
                        NormalizedEmail = "JAN.STERLE@GMAIL.COM",
                        UserName = "jan.sterle@gmail.com",
                        NormalizedUserName = "jan.sterle@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = "051866321",
                        Discriminator = "Patient",
                        SecurityStamp = Guid.NewGuid().ToString("D"),

                },
                new ApplicationUser
                {
                        Id = "7",
                        FirstName = "Tim",
                        LastName = "Marinsek",
                        Email = "tim.marinsek@gmail.com",
                        NormalizedEmail = "TIM.MARINSEK@GMAIL.COM",
                        UserName = "tim.marinsek@gmail.com",
                        NormalizedUserName = "tim.marinsek@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = "070755331",
                        Discriminator = "Patient",
                        SecurityStamp= Guid.NewGuid().ToString("D"),
                },
                new ApplicationUser
                {
                    Id = "8",
                    FirstName = "Nejc",
                    LastName = "Narobe",
                    Email = "nejc.narobe@gmail.com",
                    NormalizedEmail = "NEJC.NAROBE@GMAIL.COM",
                    UserName = "nejc.narobe@gmail.com",
                    NormalizedUserName = "nejc.narobe@gmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    Discriminator = "Patient",
                    PhoneNumber = "123456789",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                },
                new ApplicationUser
                {
                    Id = "9",
                    FirstName = "Nejc",
                    LastName = "Sila",
                    Email = "nejc.sila@gmail.com",
                    NormalizedEmail = "NEJC.SILA@GMAIL.COM",
                    UserName = "nejc.sila@gmail.com",
                    NormalizedUserName = "nejc.sila@gmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "987654321",
                    Discriminator = "Patient",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new ApplicationUser
                {
                    Id = "10",
                    FirstName = "Rok",
                    LastName = "Novak",
                    Email = "rok.novak@gmail.com",
                    NormalizedEmail = "ROK.NOVAK@GMAIL.COM",
                    UserName = "rok.novak@gmail.com",
                    NormalizedUserName = "rok.novak@gmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "031552070",
                    Discriminator = "Patient",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }
            };

            var patients = new List<Patient>
            {
                new Patient
                {
                    Id = "6",
                    ApplicationUserId = "6",
                    Birth = new DateTime(1990, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    Sex = "M",
                    Age = 34,
                },
                new Patient
                {
                    Id = "7",
                    ApplicationUserId = "7",
                    Birth = new DateTime(1995, 5, 12, 0, 0, 0, DateTimeKind.Utc),
                    Sex = "M",
                    Age = 29
                },
                new Patient
                {
                    Id = "8",
                    ApplicationUserId = "8",
                    Birth = new DateTime(2003, 12, 12, 0, 0, 0, DateTimeKind.Utc),
                    Sex = "M",
                    Age = 20
                },
                new Patient
                {
                    Id = "9",
                    ApplicationUserId = "9",
                    Birth = new DateTime(2005, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Sex = "M",
                    Age = 18
                }

            };


            var existingUserIds = _context.ApplicationUsers.Select(u => u.Id).ToList();

            foreach (var mockUser in  mockApplicationUsersDoctors)
            {
                if (!existingUserIds.Contains(mockUser.Id))
                {
                    if (!_context.ApplicationUsers.Any(u => u.UserName == mockUser.UserName))
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(mockUser, "Test12345!");
                        mockUser.PasswordHash = hashed;
                        mockUser.Password = hashed;
                    }

                    _context.ApplicationUsers.Add(mockUser);

                    var UserRoles = new IdentityUserRole<string>[]
{
                    new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=mockUser.Id}
};

                    foreach (IdentityUserRole<string> r in UserRoles)
                    {
                        _context.UserRoles.Add(r);
                    }

                }
            }

            _context.SaveChanges();

            foreach (Doctor doctor in doctors)
            {
                _context.Doctors.Add(doctor);
            }

            _context.SaveChanges();


            foreach (var mockUser in mockApplicationUsersPatients)
            {
                if (!existingUserIds.Contains(mockUser.Id))
                {
                    if (!_context.ApplicationUsers.Any(u => u.UserName == mockUser.UserName))
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(mockUser, "Test12345!");
                        mockUser.PasswordHash = hashed;
                        mockUser.Password = hashed;
                    }

                    _context.ApplicationUsers.Add(mockUser);

                    var UserRoles = new IdentityUserRole<string>[]
{
                    new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=mockUser.Id}
};

                    foreach (IdentityUserRole<string> r in UserRoles)
                    {
                        _context.UserRoles.Add(r);
                    }

                }
            }

            _context.SaveChanges();

            foreach (Patient patient in patients)
            {
                _context.Patients.Add(patient);
            }

            _context.SaveChanges();
        }

    }
}
