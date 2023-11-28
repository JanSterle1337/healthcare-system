using System.ComponentModel.DataAnnotations;

namespace healthcare_system.ViewModels
{
    public class PatientViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Birth is required.")]
        public DateTimeOffset Birth { get; set; }

        [Required(ErrorMessage = "Sex is required field.")]
        [StringLength(1)]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Email is required field.")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        [Required(ErrorMessage ="Phone number is a required field")]
        public string PhoneNumber { get; set; }
    }
}
