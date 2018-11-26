using System.Collections.Generic;
using System.Linq;
using iOSSpecialFeatures.Shared.Realms;

namespace iOSSpecialFeatures.Repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void CreateContact();
        List<Contact> GetActiveContacts();
        IQueryable<Contact> GetContactQuery();
        void UpdateContact(Contact contact);
    }
}