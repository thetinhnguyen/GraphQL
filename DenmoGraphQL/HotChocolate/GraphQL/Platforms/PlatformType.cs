using AppAny.HotChocolate.FluentValidation;
using HotChocolate;
using HotChocolate.Types;
using HotChocolateDemo.Data;
using HotChocolateDemo.GraphQL.DataLoader;
using HotChocolateDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateDemo.GraphQL.Platforms
{
    public class PlatformType: ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the name for the platform.");

            descriptor
                .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p =>  p.GetCommandsAsync(default!, default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of available commands for this platform.");
        }

        private class Resolvers
        {
            public async Task<IEnumerable<Command>>  GetCommandsAsync(Platform platform, 
                [Service] CommandByIdDataLoader commandByIdDataLoader,
                [Service] CancellationToken cancellationToken)
            {
                var result = await commandByIdDataLoader.LoadAsync(platform.Id, cancellationToken);
                return result;
            }
        }
    }
}

