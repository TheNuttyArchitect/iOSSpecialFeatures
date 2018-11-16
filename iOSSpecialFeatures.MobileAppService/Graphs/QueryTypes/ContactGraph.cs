using System;
using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Data.Models;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class ContactGraph : ObjectGraphType<Contact>
    {
        public ContactGraph()
        {
            ContactFieldBuilder.Build<ContactPhoneGraph, ContactEmailGraph>(this);
        }
    }

    public class ContactInput : InputObjectGraphType<Contact>
    {
        public ContactInput()
        {
            ContactFieldBuilder.BuildInput<ContactPhoneInput, ContactEmailInput>(this);
        }
    }

    public class ContactFieldBuilder : ComplexGraphType<Contact>
    {
        public static void BuildInput<TPhone, TEmail>(InputObjectGraphType<Contact> entity)
            where TPhone : ComplexGraphType<ContactPhone>
            where TEmail : ComplexGraphType<ContactEmail>
        {
            Build<TPhone, TEmail>(entity, "Input");
        }

        public static void Build<TPhone, TEmail>(ComplexGraphType<Contact> entity, string nameSuffix = "")
            where TPhone : ComplexGraphType<ContactPhone>
            where TEmail : ComplexGraphType<ContactEmail>
        {
            entity.Name = "Contact" + nameSuffix;
            entity.Field<NullableGuidGraph>(nameof(Contact.ContactID).ToCamelCase(), resolve: context => context.Source.ContactID);
            entity.Field(c => c.FirstName);
            entity.Field(c => c.MiddleName, nullable: true);
            entity.Field(c => c.LastName);
            entity.Field(c => c.IsFriend);
            entity.Field(c => c.NickName, nullable: true);
            entity.Field<NullableDateTimeGraph>("createdDate", resolve: ctx => ctx.Source.CreatedDate);
            entity.Field<NullableDateTimeGraph>("lastModifiedDate", resolve: ctx => ctx.Source.LastModifiedDate);
            entity.Field<ListGraphType<TPhone>>("phoneNumbers", resolve: context => context.Source.PhoneNumbers);
            entity.Field<ListGraphType<TEmail>>("emailAddresses", resolve: context => context.Source.EmailAddresses);
        }

    }
}
