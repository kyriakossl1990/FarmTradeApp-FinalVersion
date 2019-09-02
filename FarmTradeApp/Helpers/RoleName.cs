using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Helpers
{
    public class RoleName
    {
        public const string Administrator = "Administrator";
        public const string Buyer = "Buyer";
        public const string Seller = "Seller";
        public const string BuyerOrSeller = Buyer + "," + Seller;
    }
}