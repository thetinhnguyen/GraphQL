using HotChocolate;
using HotChocolate.Types;
using HotChocolateDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateDemo.GraphQL
{
    public class Subscription
    {
        /// <summary>
        /// The subscription for added <see cref="Platform"/>.
        /// </summary>
        /// <param name="platform">The <see cref="Platform"/>.</param>
        /// <returns>The added <see cref="Platform"/>.</returns>
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added platform.")]
        public Platform OnPlatformAdded([EventMessage] Platform platform)
        {
            return platform;
        }
    }
}
