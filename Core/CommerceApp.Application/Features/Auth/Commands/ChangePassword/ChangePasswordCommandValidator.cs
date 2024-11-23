using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommandRequest>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(30);
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.ConfirmPassword).NotEmpty().Equal(p => p.Password);
            RuleFor(p => p.NewPassword).NotEmpty();
        }
    }
}
