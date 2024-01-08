using healthcare_system.Data;
using healthcare_system.Models;
using healthcare_system.Repository;
using healthcare_system.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace healthcare_system.Controllers
{
    public class PatientController : Controller
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly ITermReservationRepository _termReservationRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientController(
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            ITermReservationRepository termReservationRepository,
            IApplicationUserRepository applicationUserRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _termReservationRepository = termReservationRepository;
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Index() 
        {

            ApplicationUser loggedInAccount = await GetCurrentUser();

            List<Patient> patients = _patientRepository.GetAll();
            return View(patients);
        }

        [Authorize(Roles = "Patient")]
        [Route("/account/profile/patient")]
        public async Task<IActionResult> PatientAccount()
        {
            ApplicationUser patientAccount = await GetCurrentUser();
            Patient patient = _patientRepository.GetById(patientAccount.Id);
            List<TermReservation> pastTerms = _termReservationRepository.GetPastTermsForPatient(patientAccount.Id);
            List<TermReservation> futureTerms = _termReservationRepository.GetFutureTermsForPatient(patientAccount.Id);

            PatientProfileModelView patientProfileModelView = new PatientProfileModelView();
            patientProfileModelView.patientAccount = patientAccount;
            patientProfileModelView.patient = patient;
            patientProfileModelView.pastTerms = pastTerms;
            patientProfileModelView.futureTerms = futureTerms;

            return View(patientProfileModelView);

        }


        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(User);
        }
    }
}
