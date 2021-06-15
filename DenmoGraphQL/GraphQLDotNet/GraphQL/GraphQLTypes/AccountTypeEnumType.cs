using GraphQL.Types;
using GraphQLDotNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType: EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}
