﻿using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class ContactEmailGraph : ObjectGraphType<ContactEmail>
    {
        public ContactEmailGraph()
        {
            ContactEmailFieldBuilder.Build(this);
        }
    }
}
