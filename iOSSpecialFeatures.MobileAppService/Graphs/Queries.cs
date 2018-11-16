using System;
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

            Field<ContactGraph>
            (
                "contact",
                arguments: new QueryArguments(new QueryArgument<NullableGuidGraph>{ Name = "contactID"}),
                resolve: ctx => contactRepository.GetContact(ctx.GetArgument<Guid>("contactID"))
            );

            Field<ChangeDataGraph>
            (
                "changes",
                resolve: ctx  => contactRepository.HasDataChanged()
            );
        }
    }
}
