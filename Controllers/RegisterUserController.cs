using Microsoft.AspNetCore.Mvc;
using healthcare_system.Models;
using System.Diagnostics;
using healthcare_system.ViewModels;

namespace healthcare_system.Controllers
{
    public class RegisterUserController : Controller
    {

        private readonly ILogger<RegisterUserController> _logger;

        public RegisterUserController(ILogger<RegisterUserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatientViewModel patientViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(patientViewModel);
            }

            //some other business logic
            //save patient to db

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
