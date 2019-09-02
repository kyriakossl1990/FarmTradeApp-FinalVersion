using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName +" " + LastName;
            }
        }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}