using healthcare_system.Models;
using Microsoft.EntityFrameworkCore;

namespace healthcare_system.Data.Mock
{
    public class DbSeeder
    {

        private readonly ApplicationDbContext _context;
        protected PatientMock _patientMock;
        protected HospitalMock _hospitalMock;

        public DbSeeder(
            ApplicationDbContext context, 
            PatientMock patientMock,
            HospitalMock hospitalMock
            ) 
        {
            _context = context;
            _patientMock = patientMock;
            _hospitalMock = hospitalMock;
        }

        public void SeedData()
        {
 
            _patientMock.seedPatients();
            _hospitalMock.seedHospitals();
 
        }
    }
}
