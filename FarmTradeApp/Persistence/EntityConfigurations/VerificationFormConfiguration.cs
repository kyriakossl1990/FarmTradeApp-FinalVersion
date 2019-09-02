using FarmTradeApp.Core.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence.EntityConfigurations
{
    public class VerificationFormConfiguration : EntityTypeConfiguration<VerificationForm>
    {
        public VerificationFormConfiguration()
        {
            HasKey(f => f.UserId);
        }
    }
}