using System;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{
    public class BirthInfo : RealmObject
    {
        [PrimaryKey, MapTo("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [MapTo("date")]
        public DateTimeOffset Date { get; set; }

        [MapTo("city")]
        public string City { get; set; }

        [MapTo("state")]
        public string State { get; set; }

        [MapTo("country")]
        public string Country { get; set; }

        [Required, MapTo("isActive"), Indexed]
        public bool IsActive { get; set; } = true;

        [Required, MapTo("audit")]
        public AuditData Audit { get; set; } = new AuditData();
    }
}
