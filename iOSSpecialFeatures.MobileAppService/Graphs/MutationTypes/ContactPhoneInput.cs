using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;
using iOSSpecialFeatures.Shared.Models;

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
