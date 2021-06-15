using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateDemo.GraphQL.Commands
{
    public class AddCommandPayloadType : ObjectType<AddCommandPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddCommandPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added command.");

            descriptor
                .Field(c => c.command)
                .Description("Represents the added command.");

            base.Configure(descriptor);
        }
    }
}
