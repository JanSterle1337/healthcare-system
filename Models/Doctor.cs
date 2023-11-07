﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthcare_system.Models
{
    public class Doctor
    {
        public string DoctorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [ForeignKey("Department")]
        public string DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<TermReservation> Terms { get; set; }
    }
}
