using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using iOSSpecialFeatures.Shared.Models;
using iOSSpecialFeatures.Shared.Repositories;

namespace iOSSpecialFeatures.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public ContactRepository()
        {
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> DeleteContact(Guid contactID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var contactsQuery = @"{ 
                contacts {
                    contactID
                    firstName
                    middleName
                    lastName
                    nickName
                    isFriend
                    createdDate
                    lastModifiedDate
                }
            }";

            var request = new GraphQLRequest { Query = contactsQuery };
            var client = new GraphQLClient(App.BackendUrl + "/api/graph");
            var response = await client.PostAsync(request);
            return response.GetDataFieldAs<List<Contact>>("contacts");
        }

        public async Task<Contact> GetContact(Guid contactID)
        {
            throw new NotImplementedException();
        }

        public async Task<ChangeDataHash> HasDataChanged()
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
