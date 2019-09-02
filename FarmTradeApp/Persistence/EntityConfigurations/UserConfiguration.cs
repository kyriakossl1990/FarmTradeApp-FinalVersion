using FarmTradeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            HasMany(u => u.PersonalMessages)
                .WithRequired(m => m.Sender)
                .WillCascadeOnDelete(false);

            HasMany(u => u.PersonalMessages)
                .WithRequired(m => m.Receiver)
                .WillCascadeOnDelete(false);

            HasMany(u => u.ContactForms)
                .WithRequired(m => m.Sender)
                .WillCascadeOnDelete(false);

            HasOptional(u => u.VerificationForm)
                .WithRequired(f => f.User);
        }
    }
}