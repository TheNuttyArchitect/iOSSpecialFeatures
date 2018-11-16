using System;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace iOSSpecialFeatures.MobileAppService.Graphs
{
    public class NullableGuidGraph : ScalarGraphType
    {
        public NullableGuidGraph()
        {
            Name = "NullableGuid";
        }

        public override object ParseLiteral(IValue value)
        {
            var stringVal = value as StringValue;

            return !string.IsNullOrWhiteSpace(stringVal?.Value) ? Guid.Parse(stringVal.Value) : default(Guid);
        }

        public override object ParseValue(object value)
        {
            return value != null ? Guid.Parse(value.ToString()) : default(Guid);
        }

        public override object Serialize(object value)
        {
            return value != null ? value.ToString() : default(Guid).ToString();
        }
    }
}
