﻿using System;
using System.ComponentModel;
using Realms;

namespace iOSSpecialFeatures.Shared.Realms
{

    public class AuditData : RealmObject, INotifyPropertyChanged
    {
        [Required, MapTo("createdBy")]
        public string CreatedBy { get; set; }

        [MapTo("createdDate")]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;

        [MapTo("lastModifiedBy")]
        public string LastModifiedBy { get; set; }

        [MapTo("lastModifiedDate")]
        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}
