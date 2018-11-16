using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iOSSpecialFeatures.Shared.Models
{
    [Table("contact")]
    public class Contact : AuditBase
    {
        [Column("contact_id"), Key]
        public Guid ContactID { get; set; } = Guid.NewGuid();
            
        [Column("first_name"), StringLength(30), Required]
        public string FirstName { get; set; }

        [Column("middle_name"), StringLength(30)]
        public string MiddleName { get; set; }

        [Column("last_name"), StringLength(30), Required]
        public string LastName { get; set; }

        [Column("nick_name"), StringLength(30)]
        public string NickName { get; set; }

        [Column("is_friend")]
        public bool IsFriend { get; set; }

        public virtual ICollection<ContactPhone> PhoneNumbers { get; set; }

        public virtual ICollection<ContactEmail> EmailAddresses { get; set; }
    }
}
