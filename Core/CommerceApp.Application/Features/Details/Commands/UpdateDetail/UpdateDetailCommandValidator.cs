using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Details.Commands.UpdateDetail
{
    public class UpdateDetailCommandValidator:AbstractValidator<UpdateDetailCommandRequest>
    {
        public UpdateDetailCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Id).GreaterThan(0);
            RuleFor(p => p.CategoryId).GreaterThan(0);
        }
    }
}
