using Microsoft.AspNetCore.Mvc;
using healthcare_system.Models;
using System.Diagnostics;
using healthcare_system.ViewModels;
using healthcare_system.Utils;
using healthcare_system.Repository;


namespace healthcare_system.Controllers
{
    public class RegisterUserController : Controller
    {

        private readonly ILogger<RegisterUserController> _logger;
        private readonly PasswordHasher _hasher;
        private readonly AgeCalculator _ageCalculator;
        private readonly IPatientRepository _patientRepository;
        private readonly UuidGenerator _uuidGenerator;

        public RegisterUserController(
            ILogger<RegisterUserController> logger, 
            PasswordHasher hasher,
            AgeCalculator ageCalculator,
            IPatientRepository patientRepository,
            UuidGenerator uuidGenerator
            )
        {
            _logger = logger;
            _hasher = hasher;
            _ageCalculator = ageCalculator;
            _patientRepository = patientRepository;
            _uuidGenerator = uuidGenerator;
            
        }

        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult Create(PatientViewModel patientViewModel) 
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("BAJE DA SO INVALID PODATKI");
                return View("Register", patientViewModel);
            }

            Console.WriteLine("BAJE DA SO OK PODATKI");
            
            String hashedPassword = _hasher.hashPassword(patientViewModel.Password);
            int age = _ageCalculator.calculateAgeFromBirth(patientViewModel.Birth.UtcDateTime);
            String uuid = _uuidGenerator.generateUuid();


            Patient patient = new Patient();
            patient.Id = uuid;
            patient.FirstName = patientViewModel.FirstName;
            patient.LastName = patientViewModel.LastName;
            patient.Age = age;
            patient.Password = hashedPassword;
            patient.Birth = patientViewModel.Birth.UtcDateTime;
            patient.Sex = patientViewModel.Sex;
            patient.Email = patientViewModel.EmailAddress;
            patient.PhoneNumber = patientViewModel.PhoneNumber;

            _patientRepository.Add(patient);

            //some other business logic
            //authentication
            //save patient to db
            return Redirect("/");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
