using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace iOSSpecialFeatures.Shared.Models
{
    public abstract class AuditBase
    {
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
