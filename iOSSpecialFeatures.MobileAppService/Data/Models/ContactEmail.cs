using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iOSSpecialFeatures.MobileAppService.Data.Models
{
    [Table("contact_email")]
    public class ContactEmail : AuditBase
    {
        [Column("contact_email_id"), Key]
        public Guid ContactEmailID { get; set; } = Guid.NewGuid();

        [Column("contact_id")]
        public Guid ContactID { get; set; }

        [Column("email_address"), Required, StringLength(255)]
        public string EmailAddress { get; set; }

        [Column("phone_type"), StringLength(20)]
        public string EmailType { get; set; }

        [ForeignKey("ContactID")]
        public Contact Contact { get; set; }
    }
}
