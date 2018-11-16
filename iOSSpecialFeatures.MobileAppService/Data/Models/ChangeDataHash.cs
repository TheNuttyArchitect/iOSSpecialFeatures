using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iOSSpecialFeatures.MobileAppService.Data.Models
{
    [Table("change_data_hash")]
    public class ChangeDataHash
    {
        [Column("change_data_hash_id"), Key]
        public int ChangeDataHashID { get; set; } = 1;

        [Column("contacts_hash")]
        public int ContactsHash { get; set; }

        [Column("contact_phone_numbers_hash")]
        public int ContactPhoneNumbersHash { get; set; }

        [Column("contact_email_addresses_hash")]
        public int ContactEmailAddressesHash { get; set; }

        [NotMapped]
        public bool ContactsChanged { get; set; }

        [NotMapped]
        public bool ContactPhoneNumbersChanged { get; set; }

        [NotMapped]
        public bool ContactEmailAddressesChanged { get; set; }
    }
}
