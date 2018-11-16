using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders
{
    public class ContactPhoneFieldBuilder : ComplexGraphType<ContactPhone>
    {
        public static void Build(ComplexGraphType<ContactPhone> entity)
        {
            entity.Name = "ContactPhone";
            entity.Field<NullableGuidGraph>("contactID", resolve: context => context.Source.ContactID);
            entity.Field<NullableGuidGraph>("contactPhoneID", resolve: context => context.Source.ContactPhoneID);
            entity.Field(cp => cp.PhoneNumber);
            entity.Field(cp => cp.PhoneType);
            entity.Field<DateTimeGraphType>("createdDate", resolve: ctx => ctx.Source.CreatedDate);
            entity.Field<NullableDateTimeGraph>("lastModifiedDate", resolve: ctx => ctx.Source.LastModifiedDate);
        }
    }
}
