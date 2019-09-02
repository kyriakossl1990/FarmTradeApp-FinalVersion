using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Contacts
{
    public enum ContactFormType
    {
        [Display(Name = "Γενικά")]
        Support = 1,

        [Display(Name = "Θέματα με το site")]
        SiteIssues = 2,

        [Display(Name = "Θέματα Σύνδεσης")]
        LoginRegisterProblem = 3,

        [Display(Name = "Θέματα Logistics")]
        Logistics = 4,

        [Display(Name = "Θέματα Πωλήσεων")]
        SalesProblem = 5,

        [Display(Name = "Άλλο")]
        OtherProblem = 6
    }
}