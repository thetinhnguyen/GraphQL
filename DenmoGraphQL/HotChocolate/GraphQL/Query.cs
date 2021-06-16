using AppAny.HotChocolate.FluentValidation;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolateDemo.Data;
using HotChocolateDemo.GraphQL.Platforms;
using HotChocolateDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateDemo.GraphQL
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {
        /// <summary>
        /// Gets the queryable <see cref="Platform"/>.
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The queryable <see cref="Platform"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [UsePaging]
        [GraphQLDescription("Gets the queryable platform.")]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        /// <summary>
        /// Gets the queryable <see cref="Command"/>.
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The queryable <see cref="Command"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [UsePaging]
        [GraphQLDescription("Gets the queryable command.")]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }


        //[UseDbContext(typeof(AppDbContext))]
       
        //[GraphQLDescription("Gets the queryable platform with name")]
        //public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context,[UseFluentValidation] AddPlatformInput addPlatformInput)
        //{
        //    return context.Platforms.Where(x => x.Name == addPlatformInput.Name);

        //}
    }
}
