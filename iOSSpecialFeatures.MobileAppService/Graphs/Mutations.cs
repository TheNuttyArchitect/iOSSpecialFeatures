using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs.MutationTypes;
using iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes;
using iOSSpecialFeatures.Shared.Models;
using iOSSpecialFeatures.Shared.Repositories;

namespace iOSSpecialFeatures.MobileAppService.Graphs
{
    public class Mutations : ObjectGraphType
    {
        public Mutations(IContactRepository contactRepository)
        {
            Name = "Mutations";

            Field<ContactGraph>
            (
                "addContact",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ContactInput>> { Name = "newContact" }),
                resolve: ctx => contactRepository.AddContact(ctx.GetArgument<Contact>("newContact"))
            );

            Field<ContactGraph>
            (
                "updateContact",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ContactInput>> { Name = "updatedContact" }),
                resolve: ctx => contactRepository.UpdateContact(ctx.GetArgument<Contact>("updatedContact"))
            );

            Field<ContactGraph>
            (
                "deleteContact",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ContactInput>> { Name = "deletedContact" }),
                resolve: ctx => contactRepository.DeleteContact(ctx.GetArgument<Contact>("deletedContact").ContactID)
            );
        }
    }
}
