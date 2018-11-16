using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;

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
