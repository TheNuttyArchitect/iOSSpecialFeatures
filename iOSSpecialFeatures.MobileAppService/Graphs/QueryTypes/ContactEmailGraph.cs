using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class ContactEmailGraph : ObjectGraphType<ContactEmail>
    {
        public ContactEmailGraph()
        {
            ContactEmailFieldBuilder.Build(this);
        }
    }

    public class ContactEmailInput : InputObjectGraphType<ContactEmail>
    {
        public ContactEmailInput()
        {
            ContactEmailFieldBuilder.BuildInput(this);
        }
    }


    public class ContactEmailFieldBuilder : ComplexGraphType<ContactEmail>
    {
        public static void BuildInput(InputObjectGraphType<ContactEmail> entity)
        {
            Build(entity, "Input");
        }

        public static void Build(ComplexGraphType<ContactEmail> entity, string nameSuffix = "")
        {
            entity.Name = "ContactEmail" + nameSuffix;
            entity.Field<NullableGuidGraph>("contactID", resolve: context => context.Source.ContactID);
            entity.Field<NullableGuidGraph>("contactEmailID", resolve: context => context.Source.ContactID);
            entity.Field(ce => ce.EmailAddress);
            entity.Field(ce => ce.EmailType);
            entity.Field<NullableDateTimeGraph>("createdDate", resolve: ctx => ctx.Source.CreatedDate);
            entity.Field<NullableDateTimeGraph>("lastModifiedDate", resolve: ctx => ctx.Source.LastModifiedDate);
        }
    }
}
