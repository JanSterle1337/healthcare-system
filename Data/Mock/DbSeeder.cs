using healthcare_system.Models;
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

        public DbSeeder(
            ApplicationDbContext context, 
            PatientMock patientMock,
            HospitalMock hospitalMock,
            DepartmentMock departmentMock,
            DoctorMock doctorMock,
            MedicineMock medicineMock
            ) 
        {
            _context = context;
            _patientMock = patientMock;
            _hospitalMock = hospitalMock;
            _departmentMock = departmentMock;
            _doctorMock = doctorMock;
            _medicineMock = medicineMock;
        }

        public void SeedData()
        {
            _patientMock.seedPatients();
            _hospitalMock.seedHospitals();
            _departmentMock.seedDepartments();
            _doctorMock.seedDoctors();
            _medicineMock.seedMedicine();
        }
    }
}
