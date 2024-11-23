using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandRequest : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
