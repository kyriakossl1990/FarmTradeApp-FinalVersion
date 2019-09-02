using FarmTradeApp.Core.Models.Contacts;
using System.Collections.Generic;

namespace FarmTradeApp.Core.Repositories
{
    public interface IContactFormRepository
    {
        void Add(ContactForm contactForm);
        IEnumerable<ContactForm> GetContactForms();
        ContactForm GetContactForm(int Id);
    }
}