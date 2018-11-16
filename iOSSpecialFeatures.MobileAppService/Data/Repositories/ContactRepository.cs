using System;
using System.Collections.Generic;
using System.Linq;
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
            return await RootContactQuery
                .ToListAsync();
        }

        public async Task<Contact> GetContact(Guid contactID)
        {
            return await RootContactQuery
                .SingleOrDefaultAsync(c => c.ContactID == contactID);
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            await dataContext.Contacts.AddAsync(contact);
            await dataContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var dbContact = await RootContactQueryNonTracked.SingleAsync(c => c.ContactID == contact.ContactID);
            contact.LastModifiedDate = DateTime.Now;

            if(contact.EmailAddresses != null)
            {
                foreach(var emailAddress in contact.EmailAddresses)
                {
                    var dbEmailAddress = dbContact.EmailAddresses.SingleOrDefault(e => e.ContactEmailID == emailAddress.ContactEmailID);
                    if(dbEmailAddress != null && dbEmailAddress != emailAddress)
                    {
                        emailAddress.LastModifiedDate = DateTime.Now;
                        dataContext.ContactEmailAddresses.Attach(emailAddress);
                        dataContext.Entry(emailAddress).State = EntityState.Modified;
                    }
                }
            }

            if(contact.PhoneNumbers != null)
            {
                foreach(var phoneNumber in contact.PhoneNumbers)
                {
                    var dbPhoneNumber = dbContact.PhoneNumbers.SingleOrDefault(p => p.ContactPhoneID == phoneNumber.ContactPhoneID);
                    if(dbPhoneNumber != null && dbPhoneNumber != phoneNumber)
                    {
                        phoneNumber.LastModifiedDate = DateTime.Now;
                        dataContext.ContactPhoneNumbers.Attach(phoneNumber);
                        dataContext.Entry(phoneNumber).State = EntityState.Modified;
                    }
                }
            }

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

        private IQueryable<Contact> RootContactQuery => 
            dataContext.Contacts
                .Include(c => c.PhoneNumbers)
                .Include(c => c.EmailAddresses);

        private IQueryable<Contact> RootContactQueryNonTracked =>
            dataContext.Contacts.AsNoTracking()
                .Include(c => c.PhoneNumbers).AsNoTracking()
                .Include(c => c.EmailAddresses).AsNoTracking();
    }
}
