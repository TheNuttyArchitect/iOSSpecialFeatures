using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;
using iOSSpecialFeatures.Shared.Models;

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
