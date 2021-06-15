using GraphQL.Types;
using GraphQLDotNet.GraphQL.GraphQLQueries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.GraphQL.GraphQLSchema
{
    public class AppSchema: Schema
    {
        public AppSchema(IServiceProvider provider )
            :base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();

        }
    }
}
