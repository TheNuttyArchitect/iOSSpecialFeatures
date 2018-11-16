using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iOSSpecialFeatures.Shared.Models
{
    [Table("contact_phone")]
    public class ContactPhone : AuditBase
    {
        [Column("contact_phone_id"), Key]
        public Guid ContactPhoneID { get; set; } = Guid.NewGuid();

        [Column("contact_id")]
        public Guid ContactID { get; set; }

        [Column("phone_number"), Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        [Column("phone_type"), StringLength(20)]
        public string PhoneType { get; set; }

        [ForeignKey("ContactID")]
        public Contact Contact { get; set; }
    }
}
