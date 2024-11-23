using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommandRequest>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);
            RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
        }
    }
}
