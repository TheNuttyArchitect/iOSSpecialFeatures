using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders;

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
