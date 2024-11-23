using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Details.Commands.DeleteDetail
{
    public class DeleteDetailCommandValidator : AbstractValidator<DeleteDetailCommandRequest>
    {
        public DeleteDetailCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
