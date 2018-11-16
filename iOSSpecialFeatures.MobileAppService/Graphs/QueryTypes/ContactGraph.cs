using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;
using iOSSpecialFeatures.Shared.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class ContactGraph : ObjectGraphType<Contact>
    {
        public ContactGraph()
        {
            ContactFieldBuilder.Build<ContactPhoneGraph, ContactEmailGraph>(this);
        }
    }
}
