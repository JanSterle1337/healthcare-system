using System.ComponentModel.DataAnnotations;


namespace healthcare_system.ViewModels
{
    public class DoctorLoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalid parameters")]
        public string Password { get; set; }

    }
}
