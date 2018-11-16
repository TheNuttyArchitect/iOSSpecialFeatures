using System;
using GraphQL;

namespace iOSSpecialFeatures.MobileAppService.Graphs
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<Queries>();
            Mutation = resolver.Resolve<Mutations>();
        }
    }
}
