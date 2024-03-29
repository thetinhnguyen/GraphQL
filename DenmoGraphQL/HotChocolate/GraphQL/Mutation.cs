﻿using AppAny.HotChocolate.FluentValidation;
using FluentValidation;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolateDemo.Data;
using HotChocolateDemo.GraphQL.Commands;
using HotChocolateDemo.GraphQL.Platforms;
using HotChocolateDemo.GraphQL.Validatiors;
using HotChocolateDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateDemo.GraphQL
{
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {
        /// <summary>
        /// Adds a <see cref="Platform"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddPlatformInput"/>.</param>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <param name="eventSender">The <see cref="ITopicEventSender"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The added <see cref="Platform"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a platform.")]
        public async Task<AddPlatformPayload> AddPlatformAsync(
          [UseFluentValidation] AddPlatformInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
        {

            var platform = new Platform
            {
                Name = input.Name
            };
            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }
        /// <summary>
        /// Adds a <see cref="Command"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddCommandInput"/>.</param>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The added <see cref="Command"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a command.")]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,
            [ScopedService] AppDbContext context)
        {
            var command = new Command
            {
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }


    }
}
