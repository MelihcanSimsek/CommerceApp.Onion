using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Details.Commands.CreateDetail
{
    public class CreateDetailCommandValidator:AbstractValidator<CreateDetailCommandRequest>
    {
        public CreateDetailCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.CategoryId).GreaterThan(0);
        }
    }
}
