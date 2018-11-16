using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders
{
    public class ContactEmailFieldBuilder : ComplexGraphType<ContactEmail>
    {
        public static void Build(ComplexGraphType<ContactEmail> entity)
        {
            entity.Name = "ContactEmail";
            entity.Field<NullableGuidGraph>("contactID", resolve: context => context.Source.ContactID);
            entity.Field<NullableGuidGraph>("contactEmailID", resolve: context => context.Source.ContactEmailID);
            entity.Field(ce => ce.EmailAddress);
            entity.Field(ce => ce.EmailType);
            entity.Field<DateTimeGraphType>("createdDate", resolve: ctx => ctx.Source.CreatedDate);
            entity.Field<NullableDateTimeGraph>("lastModifiedDate", resolve: ctx => ctx.Source.LastModifiedDate);
        }
    }
}
