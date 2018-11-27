using System;
using System.ComponentModel;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{
    public class EmailAddress : RealmObject, INotifyPropertyChanged
    {
        [PrimaryKey, MapTo("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required, MapTo("address")]
        public string Address { get; set; }

        [Required, MapTo("addressType")]
        public string AddressType { get; set; }

        [MapTo("isActive"), Indexed]
        public bool IsActive { get; set; } = true;

        [MapTo("audit")]
        public AuditData Audit { get; set; } = new AuditData();
    }
}
