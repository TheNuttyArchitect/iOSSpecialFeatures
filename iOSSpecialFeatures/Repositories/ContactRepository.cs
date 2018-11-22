using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iOSSpecialFeatures.Shared.Realms;
using Realms;
using Realms.Sync;

namespace iOSSpecialFeatures.Repositories
{
    public class ContactRepository
    {
        private const string AuthServerURL = "https://devtownbenplayground.us1a.cloud.realm.io";
        private const string ServerURL = "realms://devtownbenplayground.us1a.cloud.realm.io/~/playground";
        private Realm _realm;

        public ContactRepository()
        {
            var loginTask = Task.Run<User>
            (
                async () => 
                    await User.LoginAsync
                    (
                        Credentials.UsernamePassword
                        (
                            "bchesnut@developertown.com", 
                             "welcome@1", 
                             false
                        ), 
                        new Uri(AuthServerURL)
                    )
            );

            loginTask.Wait();
            var user = loginTask.Result;

            var syncConfig = new FullSyncConfiguration(new Uri(ServerURL), user)
            {
                ObjectClasses = new[]
                {
                    typeof(AuditData),
                    typeof(BirthInfo),
                    typeof(EmailAddress),
                    typeof(PhoneNumber),
                    typeof(StreetAddress),
                    typeof(Contact)
                }
            };

            _realm = Realm.GetInstance(syncConfig);

        }

        public List<Contact> GetActiveContacts()
        {
            return GetContactQuery().Where(c => c.IsActive).ToList();
        }

        public IQueryable<Contact> GetContactQuery()
        {
            return _realm.All<Contact>();
        }

        public void AddContact(Contact contact)
        {
            _realm.Write(() => _realm.Add(contact));
        }

        public void UpdateContact(Contact contact)
        {
            _realm.Write(() => _realm.Add(contact, update: true));
        }


        public void CreateContact()
        {
            var contact = new Contact
            {
                FirstName = "Kylan",
                LastName = "Davidson",
                NickName = "Kyl",
                Birth = new BirthInfo {
                    City = "Speedway",
                    Country = "USA",
                    Date = DateTimeOffset.Parse("02/07/95"),
                //    Audit = new AuditData {
                //         CreatedBy = "Ben"
                //    }
                },
                CountryOfCitizenship = "USA",
                CountryOfResidence = "USA",
                PermanentStreetAddress = new StreetAddress {
                    Line1 = "8801 North Meridian",
                    City = "Indianapolis",
                    State = "IN",
                    PostalCode = "46220",
                    Country = "USA"
                }            
            };
            contact.Audit.CreatedBy = "Ben";
            contact.Birth.Audit.CreatedBy = "Ben";
            contact.PermanentStreetAddress.Audit.CreatedBy = "Ben";
            contact.EmailAddresses.Add
            (
                new EmailAddress 
                {
                    Address = "kylan@foobar.mail",
                    AddressType = "Personal",
                }
            );
            foreach(var address in contact.EmailAddresses)
            {
                address.Audit.CreatedBy = "Ben";
            }
            contact.PhoneNumbers.Add
            (
                new PhoneNumber 
                {
                    Number = "317-500-2222",
                    NumberType = "Mobile"
                }
            );
            foreach(var phone in contact.PhoneNumbers)
            {
                phone.Audit.CreatedBy = "Ben";
            }


            //_realm.Add<Contact>(contact);
            _realm.Write(() => _realm.Add<Contact>(contact));
        }
    }
}
