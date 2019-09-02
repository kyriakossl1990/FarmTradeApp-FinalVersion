using FarmTradeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.CustomValidations
{
    public class AuctionInProgress : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var marketEntry = (MarketEntryFormViewModel)validationContext.ObjectInstance;
            //DateTime currentTime = Convert.ToDateTime(marketEntry.EntryDate);
            var currentTime = Convert.ToDateTime(value);
            DateTime marketInAuction = Convert.ToDateTime("15:45:00 PM");
            DateTime marketStartsAt = Convert.ToDateTime("09:00:00 AM");
            DateTime marketClosesAt = Convert.ToDateTime("15:00:00 PM");
            //market is open
            TimeSpan marketIsOn = currentTime - marketStartsAt;
            TimeSpan marketIsOnContinue = marketClosesAt - currentTime;
            bool marketIsOpen = (marketIsOn.Minutes > 0) && (marketIsOnContinue.Minutes > 0);
            //market is in auction phase
            TimeSpan marketAuctionStarted = currentTime - marketClosesAt;
            TimeSpan marketAuctionEnds = marketInAuction - currentTime;
            bool marketInAuctionPhase = ((marketAuctionStarted.Minutes > 0) && (marketAuctionEnds.Minutes > 0));
            if (marketInAuctionPhase)
                return new ValidationResult("You cannot place an order. The market is in Auction Phase");
            if (!marketIsOpen)
                return new ValidationResult("The market is not Open! You cannot place an order!");
            return ValidationResult.Success; // market is open so you can place an order
        }
    }
}