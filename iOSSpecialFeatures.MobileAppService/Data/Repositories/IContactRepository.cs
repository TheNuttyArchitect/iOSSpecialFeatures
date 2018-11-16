using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iOSSpecialFeatures.MobileAppService.Data.Models;

namespace iOSSpecialFeatures.MobileAppService.Data.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> AddContact(Contact contact);
        Task<Contact> DeleteContact(Guid contactID);
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContact(Guid contactID);
        Task<Contact> UpdateContact(Contact contact);
        Task<ChangeDataHash> HasDataChanged();
    }
}