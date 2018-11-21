using System;
using System.Collections.Generic;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{
    public class Contact : RealmObject
    {
        [PrimaryKey, MapTo("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required, MapTo("firstName")]
        public string FirstName { get; set; }

        [MapTo("middleName")]
        public string MiddleName { get; set; }

        [Required, MapTo("lastName")]
        public string LastName { get; set; }

        [MapTo("nickName")]
        public string NickName { get; set; }

        [MapTo("birth")]
        public BirthInfo Birth { get; set; }

        [MapTo("countryOfCitizenship")]
        public string CountryOfCitizenship { get; set; }

        [MapTo("countryOfResidence")]
        public string CountryOfResidence { get; set; }

        [MapTo("permanentStreetAddress")]
        public StreetAddress PermanentStreetAddress { get; set; }

        [MapTo("emailAddresses")]
        public IList<EmailAddress> EmailAddresses { get; }

        [MapTo("phoneNumbers")]
        public IList<PhoneNumber> PhoneNumbers { get; }

        [MapTo("isActive"), Indexed]
        public bool IsActive { get; set; } = true;

        [MapTo("audit")]
        public AuditData Audit { get; set; } = new AuditData();
    }
}
