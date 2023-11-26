using System.ComponentModel.DataAnnotations;


namespace healthcare_system.ViewModels
{
    public class DoctorLoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
