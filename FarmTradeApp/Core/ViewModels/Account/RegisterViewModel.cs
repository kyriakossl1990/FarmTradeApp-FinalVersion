using FarmTradeApp.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.ViewModels.Account
{
    public class RegisterViewModel
    {
        public int TaxNumber { get; set; }
        public DateTime DateAccountCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LandlineNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public bool IsBanned { get; set; }
        public string Role { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Ο αριθμός πρέπει να έχει 10 νούμερα")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}