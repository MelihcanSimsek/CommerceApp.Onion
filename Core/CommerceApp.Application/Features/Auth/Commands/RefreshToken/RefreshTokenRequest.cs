using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenRequest:IRequest<RefreshTokenResponse>
    {
        public string AccessToken { get; set; }
    }
}
