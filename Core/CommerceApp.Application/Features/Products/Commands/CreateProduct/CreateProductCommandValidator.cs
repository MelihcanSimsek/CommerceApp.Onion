using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.BrandId).GreaterThan(0);
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Discount).GreaterThanOrEqualTo(0);
            RuleFor(p => p.CategoryIds).NotEmpty().Must(c => c.Any());
        }
    }
}
