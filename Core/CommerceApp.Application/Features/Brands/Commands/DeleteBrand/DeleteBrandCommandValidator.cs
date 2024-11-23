using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommandRequest>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
