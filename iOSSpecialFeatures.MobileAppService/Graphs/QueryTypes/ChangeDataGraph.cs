using System;
using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class ChangeDataGraph : ObjectGraphType<ChangeDataHash>
    {
        public ChangeDataGraph()
        {
            Field(h => h.ContactsChanged);
            Field(h => h.ContactEmailAddressesChanged);
            Field(h => h.ContactPhoneNumbersChanged);
            Field(h => h.ContactsHash);
            Field(h => h.ContactEmailAddressesHash);
            Field(h => h.ContactPhoneNumbersHash);
        }
    }
}
