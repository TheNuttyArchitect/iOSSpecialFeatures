using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;

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
