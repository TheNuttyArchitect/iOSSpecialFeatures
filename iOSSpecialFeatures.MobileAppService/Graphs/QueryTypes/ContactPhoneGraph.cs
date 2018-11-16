﻿using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class ContactPhoneGraph : ObjectGraphType<ContactPhone>
    {
        public ContactPhoneGraph()
        {
            ContactPhoneFieldBuilder.Build(this);
        }
    }
}
