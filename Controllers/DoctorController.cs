using healthcare_system.Models;
using healthcare_system.Repository;
using healthcare_system.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;

namespace healthcare_system.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITermReservationRepository _termReservationRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IDepartmentRepository _departmentRepository;   

        public DoctorController(
            IDoctorRepository doctorRepository,
            IApplicationUserRepository applicationUserRepository,
            UserManager<ApplicationUser> userManager,
            ITermReservationRepository termReservationRepository,
            IHospitalRepository hospitalRepository,
            IDepartmentRepository departmentRepository
            ) 
        {
            this._doctorRepository = doctorRepository;
            this._applicationUserRepository = applicationUserRepository;
            this._userManager = userManager;
            this._termReservationRepository = termReservationRepository;
            this._hospitalRepository = hospitalRepository;
            this._departmentRepository = departmentRepository;

        }

        [Authorize(Roles = "Doctor")]
        [Route("/account/profile/doctor")]
        public async Task<IActionResult> DoctorAccount()
        {


            ApplicationUser doctorAccount = await GetCurrentUser();
            Doctor doctor = _doctorRepository.GetById( doctorAccount.Id );
            List<TermReservation> doctorTerms = _termReservationRepository.GetAll().Where(term => term.DoctorId == doctor.Id).ToList();
            Department doctorDepartment = _departmentRepository.GetById(doctor.DepartmentId);
            doctor.Department = doctorDepartment;
            Hospital doctorHospital = _hospitalRepository.GetById(doctor.Department.HospitalId);

            DoctorProfileModelView doctorProfileModelView = new DoctorProfileModelView();
            doctorProfileModelView.doctorAccount = doctorAccount;
            doctorProfileModelView.doctor = doctor;
            doctorProfileModelView.doctorTerms = doctorTerms;
            doctorProfileModelView.hospital = doctorHospital;
            doctorProfileModelView.department = doctorDepartment;

            return View(doctorProfileModelView);
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(User);
        }

    }
}
