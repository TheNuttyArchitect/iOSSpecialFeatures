using Newtonsoft.Json;

namespace System
{
    public static class Utils
    {
        public static int GetHashObject(object value)
        {
            int hash = 0;

            var serializedObject = JsonConvert.SerializeObject
            (
                value, 
                Formatting.None, 
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
            unchecked
            {
                foreach (char c in serializedObject)
                {
                    hash = hash * 31 + c;
                }
            }

            return hash;
        }

    }
}
