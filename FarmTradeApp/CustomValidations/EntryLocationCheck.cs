using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.CustomValidations
{
    public class EntryLocationCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var marketEntry = (MarketEntry)validationContext.ObjectInstance;

            if (marketEntry.EntryType == EntryType.Demand)
            {
                if (String.IsNullOrWhiteSpace(marketEntry.DeliveryLocation))
                    return new ValidationResult("Παρακαλώ συμπληρώστε Τοποθεσία Παράδοσης");
            }

            return ValidationResult.Success;
        }
    }
}