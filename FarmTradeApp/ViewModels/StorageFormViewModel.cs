using FarmTradeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.ViewModels
{
    public class StorageFormViewModel
    {
        public Storage Storage { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}