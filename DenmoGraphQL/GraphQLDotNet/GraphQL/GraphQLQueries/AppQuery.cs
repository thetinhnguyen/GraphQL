﻿using GraphQL;
using GraphQL.Types;
using GraphQLDotNet.Contracts;
using GraphQLDotNet.GraphQL.GraphQLTypes;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.GraphQL.GraphQLQueries
{

	public class AppQuery: ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
			Field<ListGraphType<OwnerType>>(
			   "owners",
			   resolve: context => repository.GetAll()
		   );

			Field<OwnerType>(
				"owner",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
				resolve: context =>
				{
					Guid id;
					if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
					{
						context.Errors.Add(new ExecutionError("Wrong value for guid"));
						return null;
					}
					return repository.GetById(id);
				}
			);
		}
    }
}
