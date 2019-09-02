using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.CustomValidations
{
    public class EntryQuantityCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var marketEntry = (MarketEntry)validationContext.ObjectInstance;

            if (marketEntry.EntryQuantity < 500 || marketEntry.EntryQuantity > 10000)
                return new ValidationResult("Η Ποσότητα πρέπει να είναι μεταξύ 500 - 10000 κιλών");

            return ValidationResult.Success;
        }
    }
}