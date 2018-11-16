using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Repositories;
using iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes;

namespace iOSSpecialFeatures.MobileAppService.Graphs
{
    public class Queries : ObjectGraphType
    {
        public Queries(IContactRepository contactRepository)
        {
            Name = "Queries";

            Field<ListGraphType<ContactGraph>>
            (
                "contacts",
                resolve: ctx => contactRepository.GetAllContacts()
            );
        }
    }
}
