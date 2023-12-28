using healthcare_system.Data;
using healthcare_system.Models;
using healthcare_system.Repository;
using healthcare_system.ViewModels;
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

        [HttpGet("/reservation/details")]
        public IActionResult Details()
        {
            List<TermReservation> reservation = _termReservationRepository.GetAll();
            reservation.Sort((x, y) => x.Date.CompareTo(y.Date)); //sortiramo po datumu

            return View(reservation);
        }

        [HttpPost]
        public ActionResult DeleteReservation(string id, string deleteButton)
        {
            

            if (!string.IsNullOrEmpty(deleteButton))       //prevermo ce je gumb biu res prtisnen
            {
                _termReservationRepository.Remove(id);

            }
            return Redirect("/reservation/details");       // redirectamo oz refeshamo site

        }
        [HttpPost]
        public ActionResult EditReservation(string id, string editButton)
        {
            if (!string.IsNullOrEmpty(editButton))        //prevermo ce je gumb biu res prtisnen
            {
                TermReservation reservation = _termReservationRepository.GetById(id);   
                return View(reservation);
            }
            return Redirect("/reservation/details");
        }


   
        public ActionResult NewReservationPage()        
        {   
            var patientEmails = _patientRepository.GetAll().Select(patient => patient.EmailAddress);
            ViewData["PatientEmails"] = new SelectList(patientEmails);

            return View("NewReservation");
        }

        public ActionResult BackToDetails()
        {
            return Redirect("/reservation/details");
        }

        public IActionResult EditReservationSave(TermReservation tr)
        {

            TermReservation tmp = _termReservationRepository.GetById(tr.ReservationId);
            
            if(tmp.DoctorId!=null)
                tmp.DoctorId = tr.DoctorId;
            if (tmp.PatientId != null)
                tmp.PatientId = tr.PatientId;
            //if (tmp.Date != null)
            //    tmp.Date = tr.Date;
            _termReservationRepository.Update(tmp);

            return Redirect("/reservation/details");
        }



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
            termReservation.ReservationId = Guid.NewGuid().ToString("D");
            termReservation.ReservedBy = true; //reserved by doctor
            Patient pickedPatient = _patientRepository.GetPatientsByEmails(termReservationVM.Email);

            termReservation.PatientId = pickedPatient.PatientId;
            termReservation.DoctorId = _userManager.GetUserId(User);

            _termReservationRepository.Add(termReservation);


            return Redirect("/reservation/details");            //ns redirecta nazaj na page kjer vidmo vse termine
        }

    }
}
