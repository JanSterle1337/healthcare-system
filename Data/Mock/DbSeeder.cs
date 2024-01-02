using healthcare_system.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace healthcare_system.Data.Mock
{
    public class DbSeeder
    {

        private readonly ApplicationDbContext _context;
        protected PatientMock _patientMock;
        protected HospitalMock _hospitalMock;
        protected DepartmentMock _departmentMock;
        protected DoctorMock _doctorMock;
        protected MedicineMock _medicineMock;
        protected TermReservationMock _termReservationMock;

        public DbSeeder(
            ApplicationDbContext context, 
            PatientMock patientMock,
            HospitalMock hospitalMock,
            DepartmentMock departmentMock,
            DoctorMock doctorMock,
            MedicineMock medicineMock,
            TermReservationMock termReservationMock
            ) 
        {
            _context = context;
            _patientMock = patientMock;
            _hospitalMock = hospitalMock;
            _departmentMock = departmentMock;
            _doctorMock = doctorMock;
            _medicineMock = medicineMock;
            _termReservationMock = termReservationMock;
        }

        public void SeedData()
        {

            MockRemover mockRemover = new MockRemover(_context);
            mockRemover.removePreviousMockData();

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



            List<Patient> patients = _patientMock.seedPatients();
            _hospitalMock.seedHospitals();
            _departmentMock.seedDepartments();
            _doctorMock.seedDoctors();
            _medicineMock.seedMedicine();
            _termReservationMock.seedTermReservations(patients);
        }
    }
}
