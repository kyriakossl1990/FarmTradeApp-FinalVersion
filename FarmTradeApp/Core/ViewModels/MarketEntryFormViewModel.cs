using FarmTradeApp.Controllers;
using FarmTradeApp.CustomValidations;
using FarmTradeApp.Core.Models;
using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace FarmTradeApp.Core.ViewModels
{
    public class MarketEntryFormViewModel
    {
        public int Id { get; set; }
        public double EntryQuantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:n} €")]
        [Range(0.01, 100, ErrorMessage = "Η Τιμή πρέπει να είναι μεταξύ 0,01 - 100 €")]
        public decimal EntryPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

        public string DeliveryLocation { get; set; }
        public int ProductId { get; set; }
        public byte ProductQualityId { get; set; }

        [Required(ErrorMessage = "Παρακαλώ επιλέξτε Προϊόν από τη λίστα")]
        public int FinalProductId { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<FinalProduct> FinalProducts { get; set; }
        public IEnumerable<ProductQuality> ProductQualities { get; set; }
        //public ApplicationUser User { get; set; }

        
        public bool IsBuyerForm { get; set; }
        public bool FinalProductsAvailable { get; set; }
        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<MarketEntriesController, ActionResult>> update = (c => c.Update(null));
                Expression<Func<MarketEntriesController, ActionResult>> create = (c => c.Create(null));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public MarketEntryFormViewModel()
        {
            Products = new Collection<Product>();
            FinalProducts = new Collection<FinalProduct>();
            ProductQualities = new Collection<ProductQuality>();
        }
    }
}