using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace healthcare_system.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email {  get; set; }

        [Required]
        [Phone]
        public string PhoneNumber {  get; set; }

        public string Discriminator { get; set; }

    }
}
