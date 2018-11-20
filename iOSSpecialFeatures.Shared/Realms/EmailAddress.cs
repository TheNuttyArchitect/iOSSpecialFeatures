using System;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{
    public class EmailAddress : RealmObject
    {
        [PrimaryKey, MapTo("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required, MapTo("address")]
        public string Address { get; set; }

        [Required, MapTo("addressType")]
        public string AddressType { get; set; }

        [Required, MapTo("isActive"), Indexed]
        public bool IsActive { get; set; } = true;

        [Required, MapTo("audit")]
        public AuditData Audit { get; set; } = new AuditData();
    }
}
