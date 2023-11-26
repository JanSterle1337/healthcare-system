using Microsoft.AspNetCore.Mvc;
using healthcare_system.ViewModels;
using healthcare_system.Models;
using healthcare_system.Repository;
using healthcare_system.Utils;

namespace healthcare_system.Controllers
{
    public class LoginDoctorController : Controller
    {
        private readonly ILogger<LoginDoctorController> _logger;
        private readonly IDoctorRepository _doctorRepository;
        private readonly PasswordHasher _passwordHasher;


        public LoginDoctorController(ILogger<LoginDoctorController> logger, IDoctorRepository doctorRepository, PasswordHasher passwordHasher)
        {
            _logger = logger;
            _doctorRepository = doctorRepository;
            _passwordHasher = passwordHasher;

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

            List<Doctor> doctors=_doctorRepository.GetAll();

            foreach(Doctor doctor in doctors)
            {
                if(doctorLoginViewModel.Email==doctor.Email)
                {
                    
                    if (doctorLoginViewModel.Password == doctor.Password)
                    {
                        Console.WriteLine("geslo je pravo");
                        return Redirect("/login/doctor");
                    }
                    else
                    {
                        Console.WriteLine("napačni vpisni podatki");
                        return Redirect("/login/doctor");
                    }


                    //TO PRIDE K SE BODO V BAZI NARdILI TESTNI PRIMERI Z HASHANIMI GESLI
                    //string hashiranVpis = _passwordHasher.hashPassword(doctorLoginViewModel.Password);
                    //if(_passwordHasher.verifyPassword(doctorLoginViewModel.Password, doctor.Password))
                    //{
                    //    Console.WriteLine("geslo je pravo");
                    //    Console.WriteLine("valid model");
                    //    return RedirectToAction("login", "Home");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("napačni vpisni podatki");
                    //    ViewBag.Doctor = "napačni vpisni podatki";
                    //    return Redirect("/login/doctor");
                    //}
                    

                }
            }

            Console.WriteLine("vpisni podatki neobstajajo");
            return Redirect("/login/doctor");

        }
    }
}
