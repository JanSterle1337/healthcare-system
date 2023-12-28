using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace healthcare_system.ViewModels
{
    public class NewTermReservationViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Prosim izberi pacienta")]
        public string Email { get; set; }

        [Required]
        public DateTimeOffset ReservationDate { get; set; }

    }
}
