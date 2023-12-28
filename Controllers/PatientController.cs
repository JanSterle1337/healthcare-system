using healthcare_system.Data;
using healthcare_system.Models;
using healthcare_system.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace healthcare_system.Controllers
{
    public class PatientController : Controller
    {

        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Index() 
        {
            List<Patient> patients = _patientRepository.GetAll();
            return View(patients);
        }
    }
}
