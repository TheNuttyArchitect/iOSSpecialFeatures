using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class ContactPhoneGraph : ObjectGraphType<ContactPhone>
    {
        public ContactPhoneGraph()
        {
            ContactPhoneFieldBuilder.Build(this);
        }
    }

    public class ContactPhoneInput : InputObjectGraphType<ContactPhone>
    {
        public ContactPhoneInput()
        {
            ContactPhoneFieldBuilder.BuildInput(this);
        }
    }

    public class ContactPhoneFieldBuilder : ComplexGraphType<ContactPhone>
    {
        public static void BuildInput(InputObjectGraphType<ContactPhone> entity)
        {
            Build(entity, "Input");
        }

        public static void Build(ComplexGraphType<ContactPhone> entity, string nameSuffix = "")
        {
            entity.Name = "ContactPhone" + nameSuffix;
            entity.Field<NullableGuidGraph>("contactID", resolve: context => context.Source.ContactID);
            entity.Field<NullableGuidGraph>("contactPhoneID", resolve: context => context.Source.ContactID);
            entity.Field(cp => cp.PhoneNumber);
            entity.Field(cp => cp.PhoneType);
            entity.Field<NullableDateTimeGraph>("createdDate", resolve: ctx => ctx.Source.CreatedDate);
            entity.Field<NullableDateTimeGraph>("lastModifiedDate", resolve: ctx => ctx.Source.LastModifiedDate);
        }
    }
}
