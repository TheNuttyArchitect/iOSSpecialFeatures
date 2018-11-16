using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;

namespace iOSSpecialFeatures.MobileAppService.Graphs.MutationTypes
{
    public class ContactPhoneInput : InputObjectGraphType<ContactPhone>
    {
        public ContactPhoneInput()
        {
            ContactPhoneFieldBuilder.Build(this);
        }
    }
}
