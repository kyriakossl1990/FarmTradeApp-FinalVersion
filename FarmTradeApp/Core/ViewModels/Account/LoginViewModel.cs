using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Κωδικός")]
        public string Password { get; set; }

        [Display(Name = "Απομνημόνευση κωδικού για αυτή τη σελίδα")]
        public bool RememberMe { get; set; }
    }
}