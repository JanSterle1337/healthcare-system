using healthcare_system.Data;
using healthcare_system.Models;
using healthcare_system.Repository;
using healthcare_system.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace healthcare_system.Controllers
{
    public class ReservationController : Controller
    {

        private readonly ITermReservationRepository _termReservationRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public ReservationController(ITermReservationRepository termReservationRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _termReservationRepository = termReservationRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
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


        public ActionResult NewReservationPage()        //funkcija k se klice ob prtisku gumba za dodajanje terminov da navigira na novo stran
        {   
            return View("NewReservation");
        }



        public IActionResult NewReservation(TermReservation tr)         //funkcija k poslemo podatke iz page ob dodajanju novega termina
        {                                                               // in se pol shrani v bazo
           
            tr.ReservationId = Guid.NewGuid().ToString("D");
            tr.ReservedBy = true; //true je dohter    
            tr.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);     //to mormo fixat (neke tezave z formatom)
            tr.Patient = _patientRepository.GetById(tr.PatientId);
            tr.Doctor = _doctorRepository.GetById(tr.DoctorId);

            _termReservationRepository.Add(tr);
            return Redirect("/reservation/details");            //ns redirecta nazaj na page kjer vidmo vse termine
        }

    }
}
