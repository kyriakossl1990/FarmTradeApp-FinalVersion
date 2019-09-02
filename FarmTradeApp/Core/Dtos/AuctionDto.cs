using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class AuctionDto
    {
        public int Id { get; private set; }
        public DateTime AuctionEndDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}