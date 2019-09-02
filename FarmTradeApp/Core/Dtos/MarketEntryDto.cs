using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class MarketEntryDto
    {
        public int Id { get; private set; }

        public int TableId { get; set; }

        public double EntryQuantity { get; set; }
        public DateTime EntryDate { get; set; }

        public decimal EntryPrice { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string DeliveryLocation { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }

        public int AuctionId { get; set; }

        public ApplicationUserDto User { get; set; }
        public FinalProductDto FinalProduct { get; set; }
        public AuctionDto Auction { get; set; }

        public void SetTableId(int tableId)
        {
            TableId = tableId;
        }
    }
}