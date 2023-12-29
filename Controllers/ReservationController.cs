using healthcare_system.Data;
using healthcare_system.Models;
using healthcare_system.Repository;
using healthcare_system.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace healthcare_system.Controllers
{
    public class ReservationController : Controller
    {

        private readonly ITermReservationRepository _termReservationRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly UserManager<Doctor> _userManager;

        public ReservationController(
            ITermReservationRepository termReservationRepository, 
            IPatientRepository patientRepository, 
            IDoctorRepository doctorRepository,
            UserManager<Doctor> userManager
            )
        {
            _termReservationRepository = termReservationRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("/reservation/details")]
        public IActionResult Details()
        {
            /*List<TermReservation> reservation = _termReservationRepository.GetAll();
            reservation.Sort((x, y) => x.Date.CompareTo(y.Date)); //sortiramo po datumu*/

            List<TermReservation> reservations = _termReservationRepository.GetAll();
            reservations.Sort((x, y) => x.Date.CompareTo(y.Date));
            List<Tuple<TermReservation, Doctor, Patient>> reservationDetails = new List<Tuple<TermReservation, Doctor, Patient>>();


            foreach (var reservation in reservations)
            {
                Doctor doctor = _doctorRepository.GetById(reservation.DoctorId);
                Patient patient = _patientRepository.GetById(reservation.PatientId);

                reservationDetails.Add(new Tuple<TermReservation, Doctor, Patient>(reservation, doctor, patient)); 


            }

            ViewBag.ReservationDetails = reservationDetails;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteReservation(string id, string deleteButton)
        {
            

            if (!string.IsNullOrEmpty(deleteButton))       //prevermo ce je gumb biu res prtisnen
            {
                _termReservationRepository.Remove(id);

            }
            return Redirect("/reservation/details");       // redirectamo oz refeshamo site

        }


        [Authorize]
        public ActionResult EditReservation(string id, string editButton)
        {
            Console.WriteLine("Baje da gremo editat stuff#222");

            if (!string.IsNullOrEmpty(editButton))        //prevermo ce je gumb biu res prtisnen
            {
                TermReservation reservation = _termReservationRepository.GetById(id);
                String doctorIdOfReservation = reservation.DoctorId;
                Doctor doctor = _doctorRepository.GetById(reservation.DoctorId);
                List<Doctor> doctors =  _doctorRepository.GetAll().Where(d => d.Id != doctorIdOfReservation).ToList();

                Patient patient = _patientRepository.GetById(reservation.PatientId);

                EditTermReservationViewModel editTermReservationViewModel = new EditTermReservationViewModel();
                editTermReservationViewModel.doctor = doctor;
                editTermReservationViewModel.patient = patient;
                editTermReservationViewModel.ReservationId = reservation.ReservationId;
                editTermReservationViewModel.DoctorList = doctors.Select(d => new SelectListItem { Value = d.Email, Text = d.Email }).ToList();
                editTermReservationViewModel.Date = reservation.Date.DateTime;

                return View(editTermReservationViewModel);
            }
            return Redirect("/reservation/details");
        }



        [Authorize]
        public ActionResult NewReservationPage()        
        {   
            var patientEmails = _patientRepository.GetAll().Select(patient => patient.EmailAddress);
            ViewData["PatientEmails"] = new SelectList(patientEmails);

            return View("NewReservation");
        }

        [Authorize]
        public ActionResult BackToDetails()
        {
            return Redirect("/reservation/details");
        }

        [Authorize]
        public IActionResult EditReservationSave(EditTermReservationViewModel model)
        {
            Console.WriteLine("Editamo stuff wuhuuu");

            if (!ModelState.IsValid)
            {
                //return 
            }

            TermReservation termReservation = _termReservationRepository.GetById(model.ReservationId);
            termReservation.Date = model.Date;
            termReservation.TermStatus = "neizvedeno";


            if (model.SelectedDoctorEmail != null && model.SelectedDoctorEmail.Length > 0)
            {
                Doctor newDoctor = _doctorRepository.GetDoctorByEmail(model.SelectedDoctorEmail);
                termReservation.DoctorId = newDoctor.Id;
            }
            

            _termReservationRepository.Update(termReservation);
            

            /*Console.WriteLine("ReservationId: "+ model.ReservationId);
            Console.WriteLine("Date"+ model.Date.ToString());
            Console.WriteLine("Email"+ model.SelectedDoctorEmail); */

            return Redirect("/reservation/details");
        }

        [Authorize]
        [HttpPost]
        public IActionResult NewReservation(NewTermReservationViewModel termReservationVM)         //funkcija k poslemo podatke iz page ob dodajanju novega termina
        {
    
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                return BadRequest(ModelState);
            }


            TermReservation termReservation = new TermReservation();
            termReservation.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            termReservation.Date = termReservationVM.ReservationDate;
            termReservation.ReservationId = Guid.NewGuid().ToString("D");
            termReservation.ReservedBy = true; //reserved by doctor
            Patient pickedPatient = _patientRepository.GetPatientsByEmails(termReservationVM.Email);

            termReservation.PatientId = pickedPatient.PatientId;
            termReservation.DoctorId = _userManager.GetUserId(User);
            termReservation.TermStatus = "neizvedeno";

            _termReservationRepository.Add(termReservation);


            return Redirect("/reservation/details");            //ns redirecta nazaj na page kjer vidmo vse termine
        }

    }
}
