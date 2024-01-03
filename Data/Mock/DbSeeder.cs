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
        protected ApplicationUserMock _userMock;

        public DbSeeder(
            ApplicationDbContext context, 
            PatientMock patientMock,
            HospitalMock hospitalMock,
            DepartmentMock departmentMock,
            DoctorMock doctorMock,
            MedicineMock medicineMock,
            TermReservationMock termReservationMock,
            ApplicationUserMock applicationUserMock
            ) 
        {
            _context = context;
            _patientMock = patientMock;
            _hospitalMock = hospitalMock;
            _departmentMock = departmentMock;
            _doctorMock = doctorMock;
            _medicineMock = medicineMock;
            _termReservationMock = termReservationMock;
            _userMock = applicationUserMock;
        }

        public void SeedData()
        {

            MockRemover mockRemover = new MockRemover(_context);
            mockRemover.removePreviousMockData();




            _hospitalMock.seedHospitals();
            _departmentMock.seedDepartments();
            _userMock.seedApplicationUsers();
            
            
            //_doctorMock.seedDoctors();
            _medicineMock.seedMedicine();
            //List<Patient> patients = _patientMock.seedPatients();
            _termReservationMock.seedTermReservations();
        }
    }
}
