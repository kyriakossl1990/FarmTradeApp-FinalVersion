using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.ViewModels
{
    public class MarketPlace
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string EndTime { get; set; }
        public string EndTimeGreek { get; set; }
        public bool HasEntries { get; set; }

        public int CurrentYear { get { return DateTime.Now.Year; } }
        public int CurrentMonth { get { return DateTime.Now.Month; } }
    }
}