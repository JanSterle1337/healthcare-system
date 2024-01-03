using healthcare_system.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace healthcare_system.ViewModels
{
    public class EditTermReservationViewModel
    {
        public string ReservationId { get; set; }

        [Required(ErrorMessage ="Potreben je vnos novega datuma")]
        public DateTime Date { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }

        public ApplicationUser doctorAccount { get; set; }
        public ApplicationUser patientAccount {  get; set; }

        [AllowNull]
        public List<SelectListItem> DoctorList { get; set; }

        [AllowNull]
        public string SelectedDoctorEmail { get; set; }
    }
}
