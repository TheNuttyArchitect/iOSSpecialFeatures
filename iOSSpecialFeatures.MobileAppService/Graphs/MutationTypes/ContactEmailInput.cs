using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;
using iOSSpecialFeatures.Shared.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.MutationTypes
{
    public class ContactEmailInput : InputObjectGraphType<ContactEmail>
    {
        public ContactEmailInput()
        {
            ContactEmailFieldBuilder.Build(this);
        }
    }
}
