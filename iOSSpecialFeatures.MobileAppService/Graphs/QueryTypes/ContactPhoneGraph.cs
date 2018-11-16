using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;
using iOSSpecialFeatures.Shared.Models;

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
