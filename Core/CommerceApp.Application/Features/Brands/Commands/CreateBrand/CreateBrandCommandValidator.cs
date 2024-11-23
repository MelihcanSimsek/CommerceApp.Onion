using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
        }
    }
}
