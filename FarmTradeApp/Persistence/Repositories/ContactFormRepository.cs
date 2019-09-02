using FarmTradeApp.Core.Models.Contacts;
using FarmTradeApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FarmTradeApp.Persistence.Repositories
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ContactForm contactForm)
        {
            _context.ContactForms.Add(contactForm);
        }

        public ContactForm GetContactForm(int Id)
        {
            return _context.ContactForms
                .Include(cf => cf.Sender)
                .Where(cf => cf.Id == Id)
                .Single();
        }

        public IEnumerable<ContactForm> GetContactForms()
        {
            return _context.ContactForms
                .Include(cf => cf.Sender)
                .ToList();
        }
    }
}