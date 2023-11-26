using Microsoft.AspNetCore.Mvc;
using healthcare_system.ViewModels;
using healthcare_system.Models;

namespace healthcare_system.Controllers
{
    public class LoginDoctorController : Controller
    {
        private readonly ILogger<LoginDoctorController> _logger;

        public LoginDoctorController(ILogger<LoginDoctorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/login/doctor")]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost("/login/doctor")]
        public IActionResult CheckAndLogIn(DoctorLoginViewModel doctorLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("invalid model");
                return View("login", doctorLoginViewModel);

            }
            //implementirat avtentikacijo
            Console.WriteLine("valid model");
            return RedirectToAction("login", "Home");
        
        }
    }
}
