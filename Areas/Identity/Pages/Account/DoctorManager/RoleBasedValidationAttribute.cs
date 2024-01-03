using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace healthcare_system.Areas.Identity.Pages.Account.DoctorManager
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RoleBasedValidationAttribute : ValidationAttribute
    {
        private readonly string _pickedRoleProperty;
        private readonly string[] _requiredProperties;

        public RoleBasedValidationAttribute(string pickedRoleProperty, params string[] requiredProperties)
        {
            _pickedRoleProperty = pickedRoleProperty;
            _requiredProperties = requiredProperties;
        }

        /*protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var model = (RegisterModel)validationContext.ObjectInstance;

            bool pickedRole = model
        } */
    }
}
