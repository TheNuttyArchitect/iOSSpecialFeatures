using System;
using GraphQL.Types;
using iOSSpecialFeatures.Shared.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.FieldBuilders
{
    public class ContactFieldBuilder : ComplexGraphType<Contact>
    {
        public static void Build<TPhone, TEmail>(ComplexGraphType<Contact> entity)
            where TPhone : ComplexGraphType<ContactPhone>
            where TEmail : ComplexGraphType<ContactEmail>
        {
            entity.Name = "Contact";
            entity.Field<NullableGuidGraph>(nameof(Contact.ContactID).ToCamelCase(), resolve: context => context.Source.ContactID);
            entity.Field(c => c.FirstName);
            entity.Field(c => c.MiddleName, nullable: true);
            entity.Field(c => c.LastName);
            entity.Field(c => c.IsFriend);
            entity.Field(c => c.NickName, nullable: true);
            entity.Field<DateTimeGraphType>("createdDate", resolve: ctx => ctx.Source.CreatedDate);
            entity.Field<NullableDateTimeGraph>("lastModifiedDate", resolve: ctx => ctx.Source.LastModifiedDate);
            entity.Field<ListGraphType<TPhone>>("phoneNumbers", resolve: context => context.Source.PhoneNumbers);
            entity.Field<ListGraphType<TEmail>>("emailAddresses", resolve: context => context.Source.EmailAddresses);
        }

    }
}
