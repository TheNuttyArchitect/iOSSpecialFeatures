using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;
using iOSSpecialFeatures.Shared.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.MutationTypes
{
    public class ContactInput : InputObjectGraphType<Contact>
    {
        public ContactInput()
        {
            ContactFieldBuilder.Build<ContactPhoneInput, ContactEmailInput>(this);
        }
    }
}
