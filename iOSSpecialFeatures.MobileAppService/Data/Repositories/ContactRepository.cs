using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace iOSSpecialFeatures.MobileAppService.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDataContext dataContext;

        public ContactRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await dataContext.Contacts
                .Include(c => c.PhoneNumbers)
                .Include(c => c.EmailAddresses)
                .ToListAsync();
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            await dataContext.Contacts.AddAsync(contact);
            await dataContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            contact.LastModifiedDate = DateTime.Now;
            dataContext.Contacts.Attach(contact);
            dataContext.Entry(contact).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteContact(Guid contactID)
        {
            var contact = await dataContext.Contacts.FindAsync(contactID);
            dataContext.Contacts.Remove(contact);
            await dataContext.SaveChangesAsync();
            return contact;
        }
    }
}
