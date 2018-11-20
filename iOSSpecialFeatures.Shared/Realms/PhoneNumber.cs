using System;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{
    public class PhoneNumber : RealmObject
    {
        [PrimaryKey, MapTo("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required, MapTo("number")]
        public string Number { get; set; }

        [Required, MapTo("numberType")]
        public string NumberType { get; set; }

        [Required, MapTo("isActive"), Indexed]
        public bool IsActive { get; set; } = true;

        [Required, MapTo("audit")]
        public AuditData Audit { get; set; } = new AuditData();
    }
}
