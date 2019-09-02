using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.CustomValidations
{
    public class EntryDeliveryDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var marketEntry = (MarketEntry)validationContext.ObjectInstance;

            if (marketEntry.DeliveryDate < DateTime.Today.AddDays(5))
                return new ValidationResult("Η Ημερομηνία Παράδοσης πρέπει να είναι τουλάχιστον 5 μέρες απο σήμερα");

            return ValidationResult.Success;
        }
    }
}