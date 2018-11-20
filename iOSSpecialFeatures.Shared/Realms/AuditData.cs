using System;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{
    public class AuditData : RealmObject
    {
        [Required, MapTo("createdBy")]
        public string CreatedBy { get; set; }

        [Required, MapTo("createdDate")]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;

        [MapTo("lastModifiedBy")]
        public string LastModifiedBy { get; set; }

        [MapTo("lastModifiedDate")]
        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}
