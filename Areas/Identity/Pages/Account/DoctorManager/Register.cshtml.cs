// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using healthcare_system.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using healthcare_system.Repository;
using healthcare_system.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Configuration;
using healthcare_system.Areas.Identity.Pages.Account.DoctorManager;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace healthcare_system.Areas.Identity.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        public IDoctorRepository _doctorRepository;
        public IPatientRepository _patientRepository;
        public IDepartmentRepository _departmentRepository;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IDepartmentRepository departmentRepository
            )
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
      
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// 
        
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 

            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "PhoneNumber")]
            public string PhoneNumber { get; set; }

            [Required]
            public bool PickedRole { get; set; }

            //extra doctor properties
            [RoleBasedValidation(PickedRole = true)]
            [Display(Name = "Specialization")]
            public string Specialization { get; set; }

            //extra patient properties
            [RoleBasedValidation(PickedRole = false)]
            public DateTime? Birth {  get; set; }


            [RoleBasedValidation(PickedRole = false)]
            public string? Sex {  get; set; }

            [RoleBasedValidation(PickedRole = false)]
            public int? Age { get; set; }

        }

        public class RoleBasedValidationAttribute : ValidationAttribute
        {
            public bool PickedRole { get; set; }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (PickedRole)
                {
                    // If PickedRole is true (Doctor), validate Doctor-specific properties
                    // You might want to adjust the conditions based on your actual requirements
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        return new ValidationResult($"{validationContext.DisplayName} is required for Doctor role.");
                    }
                }
                else
                {
                    // If PickedRole is false (Patient), validate Patient-specific properties
                    // You might want to adjust the conditions based on your actual requirements
                    if (value == null || (value is string stringValue && string.IsNullOrWhiteSpace(stringValue)))
                    {
                        return new ValidationResult($"{validationContext.DisplayName} is required for Patient role.");
                    }
                }

                // Validation passed
                return ValidationResult.Success;
            }
        }


        public List<string> SpecializationOptions { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
           
            var departments = _departmentRepository.GetAll();

            SpecializationOptions = departments.Select(department => $"{department.DepartmentId} - {department.Name}").ToList();


            /*SpecializationOptions = new List<string>
           {
                "Hipertenzija",
                "Hematologija",
                "Gastroentrologija"
                // Add more options as needed
            }; */


            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();


            if (Input.PickedRole)
            {
                if (ModelState.GetFieldValidationState("Input.Specialization") == ModelValidationState.Invalid)
                {
                    return Page();
                }
            } else
            {
                if (ModelState.GetFieldValidationState("Input.Birth") == ModelValidationState.Invalid ||
                    ModelState.GetFieldValidationState("Input.Sex") == ModelValidationState.Invalid ||
                    ModelState.GetFieldValidationState("Input.Age") == ModelValidationState.Invalid)
                {
                    return Page();
                }
            }




       
                var user = CreateUser();
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.Email = Input.Email;
                user.Password = Input.Password;
                user.PhoneNumber = Input.PhoneNumber;
                //user.Specialization = Input.Specialization;
                //user.DepartmentId = Input.DepartmentId;
                user.Email = Input.Email;

                if (Input.PickedRole == true)
                {
                    user.Discriminator = "Doctor";
                }
                else
                {
                    user.Discriminator = "Patient";
                }


                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var userRole = new IdentityUserRole<string> { };

                    if (Input.PickedRole == true)
                    {
                        //registered user with Doctor role
                        userRole = new IdentityUserRole<string> { RoleId = "1", UserId = userId };

                        Doctor newDoctor = new Doctor();
                        newDoctor.Id = userId;
                        newDoctor.ApplicationUserId = userId;
                        String[] splittedSpecialization = Input.Specialization.Split('-');

                        newDoctor.Specialization = splittedSpecialization[1];
                        newDoctor.DepartmentId = splittedSpecialization[0];

                        _doctorRepository.Add(newDoctor);
                       
                    }
                    else
                    {
                        //registered user with Patient role
                        userRole = new IdentityUserRole<string> { RoleId = "2", UserId = userId };

                        Patient patient = new Patient();
                        patient.Id = userId;
                        patient.ApplicationUserId = userId;
                        patient.Birth = (DateTime) Input.Birth;
                        patient.Sex = Input.Sex;
                        patient.Age = (int) Input.Age;


                        
                    }

                    _context.UserRoles.Add(userRole);
                    _context.SaveChanges();


                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId, code, returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            return Page();

        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
