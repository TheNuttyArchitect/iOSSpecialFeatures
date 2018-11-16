using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iOSSpecialFeatures.MobileAppService.Graphs
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; } //https://github.com/graphql-dotnet/graphql-dotnet/issues/389

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}




