using Microsoft.AspNetCore.Mvc;
using healthcare_system.Models;
using System.Diagnostics;
using healthcare_system.ViewModels;
using healthcare_system.Utils;


namespace healthcare_system.Controllers
{
    public class RegisterUserController : Controller
    {

        private readonly ILogger<RegisterUserController> _logger;
        private readonly PasswordHasher _hasher;

        public RegisterUserController(ILogger<RegisterUserController> logger, PasswordHasher hasher)
        {
            _logger = logger;
            _hasher = hasher;
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

            Patient patient = new Patient();
            
            String hashPassword = _hasher.hashPassword(patientViewModel.Password);



            //some other business logic
            //authentication
            //save patient to db

            return RedirectToAction("Register", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
