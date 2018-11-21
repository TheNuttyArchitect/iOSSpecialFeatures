using System;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{
    public class StreetAddress : RealmObject
    {
        [PrimaryKey, MapTo("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required, MapTo("line1")]
        public string Line1 { get; set; }

        [MapTo("line2")]
        public string Line2 { get; set; }

        [MapTo("line3")]
        public string Line3 { get; set; }

        [Required, MapTo("city")]
        public string City { get; set; }

        [MapTo("state")]
        public string State { get; set; }

        [Required, MapTo("country")]
        public string Country { get; set; }

        [MapTo("postalCode")]
        public string PostalCode { get; set; }

        [MapTo("isActive"), Indexed]
        public bool IsActive { get; set; } = true;

        [MapTo("audit")]
        public AuditData Audit { get; set; } = new AuditData();
    }
}
