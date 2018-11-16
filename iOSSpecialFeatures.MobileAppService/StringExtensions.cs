using System.Dynamic;
using System.Globalization;
using System.Linq.Expressions;

namespace System
{
    public static class StringExtensions
    {
        private static TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

        public static string ToCamelCase(this string value)
        {
            if (value.Length > 0)
            {
                var char1 = Char.ToLowerInvariant(value[0]);
                return value.Length > 1 ? char1 + value.Substring(1) : char1.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string ToTitleCase(this string value)
        {
            if (value.Length > 0)
            {
                return _textInfo.ToTitleCase(value.ToLower());
            }
            else
            {
                return null;
            }
        }
    }
}
