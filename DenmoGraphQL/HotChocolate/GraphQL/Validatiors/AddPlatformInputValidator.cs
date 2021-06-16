using FluentValidation;
using HotChocolateDemo.GraphQL.Platforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateDemo.GraphQL.Validatiors
{
    public class AddPlatformInputValidator: AbstractValidator<AddPlatformInput>
    {
        public AddPlatformInputValidator()
        {
            RuleFor(input => input.Name)
              .NotEmpty()
              .WithMessage("Property is empty");
        }
    }
}
