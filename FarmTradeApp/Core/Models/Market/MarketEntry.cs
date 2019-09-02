using FarmTradeApp.CustomValidations;
using FarmTradeApp.Core.Models.Products;
using FarmTradeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Market
{
    public class MarketEntry
    {
        // * Properties * //
        public int Id { get; private set; }
        public bool IsRemoved { get; private set; }

        public DateTime EntryDate { get; private set; }

        public EntryType EntryType { get; private set; }

        [EntryQuantityCheck]
        public double EntryQuantity { get; private set; }

        [NotMapped]
        public double MatchQuantity { get; private set; }

        [DisplayFormat(DataFormatString = "{0:n} €")]
        [Range(0.01, 100, ErrorMessage = "Η Τιμή πρέπει να είναι μεταξύ 0,01 - 100 €")]
        public decimal EntryPrice { get; private set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [EntryDeliveryDateRange]
        public DateTime DeliveryDate { get; private set; }

        [EntryLocationCheck]
        public string DeliveryLocation { get; private set; }

        // Foreign Keys Properties
        public string UserId { get; private set; }
        public int AuctionId { get; private set; }

        [Required(ErrorMessage = "Παρακαλώ επιλέξτε Προϊόν από τη λίστα")]
        public int FinalProductId { get; private set; }

        // Navigation Properties
        public ApplicationUser User { get; private set; }
        public Auction Auction { get; private set; }
        public FinalProduct FinalProduct { get; private set; }

        // * Constructors * //
        // Default Constructor
        private MarketEntry()
        {}

        // Custom Constructor
        private MarketEntry(string userId, EntryType entryType, int auctionId, 
                            double entryQuantity, decimal entryPrice, DateTime deliveryDate)
        {
            UserId = userId;
            EntryType = entryType;
            DeliveryDate = DateTime.Now;
            AuctionId = auctionId;
            EntryQuantity = entryQuantity;
            EntryPrice = entryPrice;
            DeliveryDate = deliveryDate;
            EntryDate = DateTime.Now;
        }

        // * Methods *
        // Static Factory Method - Create Buyer Entry
        public static MarketEntry CreateBuyerEntry(string userId, EntryType entryType, 
                                                   int auctionId, int productId, 
                                                   byte productQualityId, double entryQuantity,
                                                   decimal entryPrice, DateTime deliveryDate,
                                                   string deliveryLocation)
        {
            var marketEntry = new MarketEntry(userId, entryType, auctionId, entryQuantity, 
                                              entryPrice, deliveryDate);

            var buyerFinalProduct = new FinalProduct()
            {
                ProductId = productId,
                QualityId = productQualityId
            };

            marketEntry.FinalProduct = buyerFinalProduct;
            marketEntry.DeliveryLocation = deliveryLocation;

            return marketEntry;
        }

        // Static Factory Method - Create Seller Entry
        public static MarketEntry CreateSellerEntry(string userId, EntryType entryType, 
                                                    int auctionId, int finalProductId,
                                                    double entryQuantity, decimal entryPrice, 
                                                    DateTime deliveryDate)
        {
            var marketEntry = new MarketEntry(userId, entryType, auctionId, entryQuantity, 
                                              entryPrice, deliveryDate);

            marketEntry.SetFinalProduct(finalProductId);

            return marketEntry;
        }

        // Update Market Entry
        public void Modify(MarketEntryFormViewModel viewModel)
        {
            EntryQuantity = viewModel.EntryQuantity;
            EntryPrice = viewModel.EntryPrice;
            DeliveryDate = viewModel.DeliveryDate;
            SetFinalProduct(viewModel.FinalProductId);
            DeliveryLocation = viewModel.DeliveryLocation;

            if (EntryType == EntryType.Demand)
                FinalProduct.Modify(viewModel.ProductId, viewModel.ProductQualityId);
        }

        // Set Final Product Id
        private void SetFinalProduct(int finalProductId)
        {
            FinalProductId = finalProductId;
        }

        // Setting Buyer Order Match Quantity
        public void SetMatchQuantity(double newMatchQuantity)
        {
            MatchQuantity = newMatchQuantity;
        }

        // Remove Market Entry
        public void Remove()
        {
            IsRemoved = true;
        }
    }
}