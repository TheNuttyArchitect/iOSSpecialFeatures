using System;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes
{
    public class NullableDateTimeGraph : ScalarGraphType
    {
        public NullableDateTimeGraph()
        {
            Name = "NullableDateTimeGraph";
        }

        public override object ParseLiteral(IValue value)
        {
            var stringVal = value as StringValue;

            return !string.IsNullOrWhiteSpace(stringVal?.ToString()) ? DateTime.Parse(stringVal.ToString()) : default(DateTime);
        }

        public override object ParseValue(object value)
        {
            return value != null ? DateTime.Parse(value.ToString()) : default(DateTime);
        }

        public override object Serialize(object value)
        {
            return value != null
                ? DateTime.Parse(value.ToString())
                : default(DateTime);
        }
    }
}
