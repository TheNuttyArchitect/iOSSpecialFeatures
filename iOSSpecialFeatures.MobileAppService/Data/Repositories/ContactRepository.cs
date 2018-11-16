using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iOSSpecialFeatures.Shared;
using iOSSpecialFeatures.Shared.Models;
using iOSSpecialFeatures.Shared.Repositories;
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
            var dbContact = await dataContext.Contacts.AsNoTracking().SingleAsync(c => c.ContactID == contact.ContactID);
            var dbPhones = await dataContext.ContactPhoneNumbers.AsNoTracking().Where(p => p.ContactID == contact.ContactID).ToListAsync();
            var dbEmails = await dataContext.ContactEmailAddresses.AsNoTracking().Where(e => e.ContactID == contact.ContactID).ToListAsync();

            contact.LastModifiedDate = DateTime.Now;

            if(contact.EmailAddresses != null)
            {
                foreach(var emailAddress in contact.EmailAddresses)
                {
                    var dbEmailAddress = dbEmails.SingleOrDefault(e => e.ContactEmailID == emailAddress.ContactEmailID);
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
                    var dbPhoneNumber = dbPhones.SingleOrDefault(p => p.ContactPhoneID == phoneNumber.ContactPhoneID);
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

        public async Task<ChangeDataHash> HasDataChanged()
        {
            var currentHash = new ChangeDataHash
            {
                ContactsHash = Utils.GetHashObject(await dataContext.Contacts.ToArrayAsync()),
                ContactPhoneNumbersHash = Utils.GetHashObject(await dataContext.ContactPhoneNumbers.ToArrayAsync()),
                ContactEmailAddressesHash = Utils.GetHashObject(await dataContext.ContactEmailAddresses.ToArrayAsync()),
            };

            var dataHash = await dataContext.DataChanges.SingleOrDefaultAsync(d => d.ChangeDataHashID == 1);
            if(dataHash != null)
            {
                if(dataHash.ContactsHash != currentHash.ContactsHash)
                {
                    dataHash.ContactsHash = currentHash.ContactsHash;
                    currentHash.ContactsChanged = true;
                }

                if(dataHash.ContactPhoneNumbersHash != currentHash.ContactPhoneNumbersHash)
                {
                    dataHash.ContactPhoneNumbersHash = currentHash.ContactPhoneNumbersHash;
                    currentHash.ContactPhoneNumbersChanged = true;
                }

                if(dataHash.ContactEmailAddressesHash != currentHash.ContactEmailAddressesHash)
                {
                    dataHash.ContactEmailAddressesHash = currentHash.ContactEmailAddressesHash;
                    currentHash.ContactEmailAddressesChanged = true;
                }
            }
            else
            {
                currentHash.ChangeDataHashID = 1;
                currentHash.ContactsChanged = true;
                currentHash.ContactEmailAddressesChanged = true;
                currentHash.ContactPhoneNumbersChanged = true;
                await dataContext.DataChanges.AddAsync(currentHash);
            }

            await dataContext.SaveChangesAsync();
            return currentHash;
        }

        private IQueryable<Contact> RootContactQuery => 
            dataContext.Contacts
                .Include(c => c.PhoneNumbers)
                .Include(c => c.EmailAddresses);
    }
}
